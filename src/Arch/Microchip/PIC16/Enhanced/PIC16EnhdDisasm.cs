﻿#region License
/* 
 * Copyright (C) 2017-2018 Christian Hostelet.
 * inspired by work from:
 * Copyright (C) 1999-2018 John Källén.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

using Reko.Core;
using Reko.Libraries.Microchip;
using System;

namespace Reko.Arch.Microchip.PIC16
{
    using Common;

    /// <summary>
    /// A Enhanced PIC16 family disassembler.
    /// </summary>
    public class PIC16EnhancedDisasm : PIC16BasicDisasm
    {
        /// <summary>
        /// Instantiates a new Enhanced PIC16 disassembler.
        /// </summary>
        /// <param name="arch">The PIC architecture.</param>
        /// <param name="rdr">The memory segment reader.</param>
        private PIC16EnhancedDisasm(PICArchitecture arch, EndianImageReader rdr)
            : base(arch, rdr)
        {
        }

        public new static PICDisassemblerBase Create(PICArchitecture arch, EndianImageReader rdr)
        {
            return new PIC16EnhancedDisasm(
                arch ?? throw new ArgumentNullException(nameof(arch)),
                rdr ?? throw new ArgumentNullException(nameof(rdr))
                );
        }

        /// <summary>
        /// Gets the PIC instruction-set identifier.
        /// </summary>
        public override InstructionSetID InstructionSetID => InstructionSetID.PIC16_ENHANCED;

        /// <summary>
        /// Disassembles a single Enhanced PIC16 instruction.
        /// First try for any instruction-set specific decoding. If fail, fall to common decoder.
        /// </summary>
        /// <returns>
        /// A <see cref="PICInstruction"/> instance.
        /// </returns>
        /// <exception cref="AddressCorrelatedException">Thrown when the Address Correlated error
        ///                                              condition occurs.</exception>
        protected override PICInstruction DecodePICInstruction(ushort uInstr, PICProgAddress addr)
        {
            var offset = rdr.Offset;
            try
            {
                var bits = uInstr.Extract(12, 2);
                instrCur = opcodesTable[bits].Decode(uInstr, this);
                if (instrCur is null)
                    return base.DecodePICInstruction(uInstr, addr);
                if (!instrCur.IsValid)
                {
                    rdr.Offset = offset;
                }
                instrCur.Address = addrCur;
                instrCur.Length = (int)(rdr.Address - addrCur);
            }
            catch (AddressCorrelatedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AddressCorrelatedException(addrCur, ex, $"An exception occurred when disassembling {InstructionSetID.ToString()} binary code 0x{uInstr:X4}.");
            }

            return instrCur;
        }


        private static Decoder[] opcodesTable = new Decoder[4]
        {
            new SubDecoder(10, 2, new Decoder[4] {                  // 00 ??.. .... ....
                new SubDecoder(8, 2, new Decoder[4] {               // 00 00?? .... ....
                    new SubDecoder(7, 1, new Decoder[2] {           // 00 0000 ?... ....
                        new SubDecoder(4, 3, new Decoder[8]{        // 00 0000 0??? ....
                            new B00_0000_0000_OpRec(),              // 00 0000 0000 ....
                            new SubDecoder(3, 1, new Decoder[2]{    // 00 0000 0001 ?...
                                new MoviIncDecOpRec(Opcode.MOVIW),  // 00 0000 0001 0...
                                new MoviIncDecOpRec(Opcode.MOVWI)   // 00 0000 0001 1...
                            }),
                            new Immed5OpRec(Opcode.MOVLB),          // 00 0000 0010 ....
                            new Immed5OpRec(Opcode.MOVLB),          // 00 0000 0011 ....
                            new InvalidOpRec(),                     // 00 0000 0100 ....
                            new InvalidOpRec(),                     // 00 0000 0101 ....
                            new B00_0000_0110_OpRec(),              // 00 0000 0110 ....
                            new InvalidOpRec()                      // 00 0000 0111 ....
                        }),
                        new UseBaseDecode(),                        // 00 0000 1... ....
                    }),
                    new SubDecoder(7, 1, new Decoder[2] {           // 00 0001 ?... ....
                        new B00_0001_0_OpRec(),                     // 00 0001 0... ....
                        new UseBaseDecode()                         // 00 0001 1... ....
                    }),
                    new UseBaseDecode(),                            // 00 0010 .... ....
                    new UseBaseDecode()                             // 00 0011 .... ....
                }),
                new UseBaseDecode(),                                // 00 01.. .... ....
                new UseBaseDecode(),                                // 00 10.. .... ....
                new UseBaseDecode(),                                // 00 11.. .... ....
            }),
            new UseBaseDecode(),                                    // 01 .... .... ....
            new UseBaseDecode(),                                    // 10 .... .... ....
            new SubDecoder(8, 4, new Decoder[16]{                   // 11 ???? .... ....
                new Immed8OpRec(Opcode.MOVLW),                      // 11 0000 .... ....
                new SubDecoder(7, 1, new Decoder[2]{                // 11 0001 ?... ....
                    new FSRArithOpRec(Opcode.ADDFSR),               // 11 0001 0... ....
                    new Immed7OpRec(Opcode.MOVLP)                   // 11 0001 1... ....
                }),
                new TargetRel9OpRec(Opcode.BRA),                    // 11 0010 .... ....
                new TargetRel9OpRec(Opcode.BRA),                    // 11 0011 .... ....
                new Immed8OpRec(Opcode.RETLW),                      // 11 0100 .... ....
                new MemoryByteWDestOpRec(Opcode.LSLF),              // 11 0101 .... ....
                new MemoryByteWDestOpRec(Opcode.LSRF),              // 11 0110 .... ....
                new MemoryByteWDestOpRec(Opcode.ASRF),              // 11 0111 .... ....
                new Immed8OpRec(Opcode.IORLW),                      // 11 1000 .... ....
                new Immed8OpRec(Opcode.ANDLW),                      // 11 1001 .... ....
                new Immed8OpRec(Opcode.XORLW),                      // 11 1010 .... ....
                new MemoryByteWDestOpRec(Opcode.SUBWFB),            // 11 1011 .... ....
                new Immed8OpRec(Opcode.SUBLW),                      // 11 1100 .... ....
                new MemoryByteWDestOpRec(Opcode.ADDWFC),            // 11 1101 .... ....
                new Immed8OpRec(Opcode.ADDLW),                      // 11 1110 .... ....
                new SubDecoder(7, 1, new Decoder[2]{                // 11 1111 ?... ....
                    new FSRIndexedOpRec(Opcode.MOVIW),              // 11 1111 0... ....
                    new FSRIndexedOpRec(Opcode.MOVWI),              // 11 1111 1... ....
                })
            })
        };

        /// <summary>
        /// A mix of instructions. Avoid huge decoder tables.
        /// </summary>
        private class B00_0000_0000_OpRec : Decoder
        {
            public override PICInstruction Decode(ushort uInstr, PICDisassemblerBase dasm)
            {
                switch (uInstr)
                {
                    case 0b00_0000_0000_0000:
                        return new PICInstructionNoOpnd(Opcode.NOP);

                    case 0b00_0000_0000_0001:
                        return new PICInstructionNoOpnd(Opcode.RESET);

                    case 0b00_0000_0000_1000:
                        return new PICInstructionNoOpnd(Opcode.RETURN);

                    case 0b00_0000_0000_1001:
                        return new PICInstructionNoOpnd(Opcode.RETFIE);

                    case 0b00_0000_0000_1010:
                        return new PICInstructionNoOpnd(Opcode.CALLW);

                    case 0b00_0000_0000_1011:
                        return new PICInstructionNoOpnd(Opcode.BRW);

                    default:
                        return new PICInstructionNoOpnd(Opcode.invalid);
                }
            }
        }

        /// <summary>
        /// An other mix of instructions. Avoid huge decoder tables.
        /// </summary>
        private class B00_0000_0110_OpRec : Decoder
        {
            public override PICInstruction Decode(ushort uInstr, PICDisassemblerBase dasm)
            {
                switch (uInstr)
                {
                    case 0b00_0000_0110_0011:
                        return new PICInstructionNoOpnd(Opcode.SLEEP);

                    case 0b00_0000_0110_0100:
                        return new PICInstructionNoOpnd(Opcode.CLRWDT);

                    case 0b00_0000_0110_0101:
                    case 0b00_0000_0110_0110:
                    case 0b00_0000_0110_0111:
                        return new PICInstructionTris(Opcode.TRIS, (byte)uInstr.Extract(0, 3));

                    default:
                        return new PICInstructionNoOpnd(Opcode.invalid);
                }
            }
        }

        /// <summary>
        /// An other mix of instructions. Avoid huge decoder tables.
        /// </summary>
        private class B00_0001_0_OpRec : Decoder
        {
            public override PICInstruction Decode(ushort uInstr, PICDisassemblerBase dasm)
            {
                switch (uInstr)
                {
                    case 0b00_0001_0000_0000:
                    case 0b00_0001_0000_0001:
                    case 0b00_0001_0000_0010:
                    case 0b00_0001_0000_0011:
                        return new PICInstructionNoOpnd(Opcode.CLRW);

                    default:
                        return new PICInstructionNoOpnd(Opcode.invalid);
                }
            }
        }

    }

}
