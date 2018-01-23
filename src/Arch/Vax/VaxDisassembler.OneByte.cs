﻿#region License
/* 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reko.Core;

namespace Reko.Arch.Vax
{
    public partial class VaxDisassembler
    {
        // http://www2.hmc.edu/www_common/OVMS072-OLD/72final/4515/4515pro_038.html#mnemonics

        private static OpRec[] oneByteInstructions = new[]
        {
 /* 00 */ new OpRec(Opcode.halt, ""), 
 /* 01 */ new OpRec(Opcode.nop, ""), 
 /* 02 */ new OpRec(Opcode.rei, ""), 
 /* 03 */ new OpRec(Opcode.bpt, ""), 
 /* 04 */ new OpRec(Opcode.ret, ""), 
 /* 05 */ new OpRec(Opcode.rsb, ""), 
 /* 06 */ new OpRec(Opcode.ldpctx, ""), 
 /* 07 */ new OpRec(Opcode.svpctx, ""), 
 /* 08 */ new OpRec(Opcode.cvtps, "rw,ab,rw,ab"), 
 /* 09 */ new OpRec(Opcode.cvtsp, "rw,ab,rw,ab"),
 /* 0A */ new OpRec(Opcode.index, "rl,rl,rl,rl,rl,wl"),
 /* 0B */ new OpRec(Opcode.crc, "ab,rl,rw,ab"), 
 /* 0C */ new OpRec(Opcode.prober, "rb,rw,ab"), 
 /* 0D */ new OpRec(Opcode.probew, "rb,rw,ab"), 
 /* 0E */ new OpRec(Opcode.insque, "ab,ab"), 
 /* 0F */ new OpRec(Opcode.remque, "ab,wl"), 

 /* 10 */ new OpRec(Opcode.bsbb, "bb"), 
 /* 11 */ new OpRec(Opcode.brb, "bb"), 
 /* 12 */ new OpRec(Opcode.bneq, "bb"),    // bnequ
 /* 13 */ new OpRec(Opcode.beql, "bb"),  // beqlu
 /* 14 */ new OpRec(Opcode.bgtr, "bb"), 
 /* 15 */ new OpRec(Opcode.bleq, "bb"), 
 /* 16 */ new OpRec(Opcode.jsb, "ab"), 
 /* 17 */ new OpRec(Opcode.jmp, "ab"), 
 /* 18 */ new OpRec(Opcode.bgeq, "bb"), 
 /* 19 */ new OpRec(Opcode.blss, "bb"), 
 /* 1A */ new OpRec(Opcode.bgtru, "bb"), 
 /* 1B */ new OpRec(Opcode.blequ, "bb"), 
 /* 1C */ new OpRec(Opcode.bvc, "bb"), 
 /* 1D */ new OpRec(Opcode.bvs, "bb"), 
 /* 1E */ new OpRec(Opcode.bgequ, "bb"), // bcc, 
 /* 1F */ new OpRec(Opcode.blssu, "bb"), //  bcs, 

 /* 20 */ new OpRec(Opcode.addp4, "rw,ab,rw,ab"),
 /* 21 */ new OpRec(Opcode.addp6, "rw,ab,rw,ab,rw,ab"),
 /* 22 */ new OpRec(Opcode.subp4, "rw,ab,rw,ab"),
 /* 23 */ new OpRec(Opcode.subp6, "rw,ab,rw,ab,rw,ab"),
 /* 24 */ new OpRec(Opcode.cvtpt, "rw,ab,ab,rw"),
 /* 25 */ new OpRec(Opcode.mulp,  "rw,ab,rw,ab,rw,ab"),
 /* 26 */ new OpRec(Opcode.cvttp, "rw,ab,ab,rw"),
 /* 27 */ new OpRec(Opcode.divp,   "rw,ab,rw,ab,rw,ab"),
 /* 28 */ new OpRec(Opcode.movc3, "rw,ab,ab"),
 /* 29 */ new OpRec(Opcode.cmpc3, "rw,ab,ab"),
 /* 2A */ new OpRec(Opcode.scanc, "rw,ab,ab,rb"),
 /* 2B */ new OpRec(Opcode.spanc, "rw,ab,ab,rb"),
 /* 2C */ new OpRec(Opcode.movc5,  -1), 
 /* 2D */ new OpRec(Opcode.cmpc5, "rw,ab,rb,rw,ab"), 
 /* 2E */ new OpRec(Opcode.movtc,  -1), 
 /* 2F */ new OpRec(Opcode.movtuc,  -1), 

 /* 30 */ new OpRec(Opcode.bsbw,  "bw"), 
 /* 31 */ new OpRec(Opcode.brw,   "bw"), 
 /* 32 */ new OpRec(Opcode.cvtwl, "rw,wl"),
 /* 33 */ new OpRec(Opcode.cvtwb, "rw,wb"), 
 /* 34 */ new OpRec(Opcode.movp,  -1), 
 /* 35 */ new OpRec(Opcode.cmpp3,  "rw,ab,ab"), 
 /* 36 */ new OpRec(Opcode.cvtpl,  -1), 
 /* 37 */ new OpRec(Opcode.cmpp4,  "rw,ab,rw,ab"), 
 /* 38 */ new OpRec(Opcode.editpc,  -1), 
 /* 39 */ new OpRec(Opcode.matchc, "rw,ab,rw,ab"), 
 /* 3A */ new OpRec(Opcode.locc,  -1), 
 /* 3B */ new OpRec(Opcode.skpc,  -1), 
 /* 3C */ new OpRec(Opcode.movzwl, "rw,wl"),
 /* 3D */ new OpRec(Opcode.acbw,  "rw,rw,mw,bw"),
 /* 3E */ new OpRec(Opcode.movaw,  "aw,wl"), 
 /* 3F */ new OpRec(Opcode.pushaw, "aw"), 
 
 /* 40 */ new OpRec(Opcode.addf2, "rf,wf"), 
 /* 41 */ new OpRec(Opcode.addf3, "rf,rf,wf"), 
 /* 42 */ new OpRec(Opcode.subf2, "rf,wf"), 
 /* 43 */ new OpRec(Opcode.subf3, "rf,rf,wf"), 
 /* 44 */ new OpRec(Opcode.mulf2, "rf,wf"), 
 /* 45 */ new OpRec(Opcode.mulf3, "rf,rf,wf"), 
 /* 46 */ new OpRec(Opcode.divf2, "rf,wf"), 
 /* 47 */ new OpRec(Opcode.divf3, "rf,rf,wf"), 
 /* 48 */ new OpRec(Opcode.cvtfb, "rf,wb"),
 /* 49 */ new OpRec(Opcode.cvtfw, "rf,ww"),
 /* 4A */ new OpRec(Opcode.cvtfl, "rf,wl"), 
 /* 4B */ new OpRec(Opcode.cvtrfl, "rf,wl"),
 /* 4C */ new OpRec(Opcode.cvtbf, "rb,wf"),
 /* 4D */ new OpRec(Opcode.cvtwf, "rw,wf"),
 /* 4E */ new OpRec(Opcode.cvtlf, "rl,wf"), 
 /* 4F */ new OpRec(Opcode.acbf,  "rf,rf,mf,bw"),

 /* 50 */ new OpRec(Opcode.movf,  "rf,wf"),
 /* 51 */ new OpRec(Opcode.cmpf,  "rf,rf"), 
 /* 52 */ new OpRec(Opcode.mnegf, "rf,wf"), 
 /* 53 */ new OpRec(Opcode.tstf,  "rf"), 
 /* 54 */ new OpRec(Opcode.emodf, "rf,rb,rd,wl,wf"), 
 /* 55 */ new OpRec(Opcode.polyf, "rf,rw,ab"), 
 /* 56 */ new OpRec(Opcode.cvtfd, "rf,wd"),
 /* 57 */ new OpRec(Opcode.Reserved ,  -1), 
 /* 58 */ new OpRec(Opcode.adawi, "rw,aw"), 
 /* 59 */ new OpRec(Opcode.Reserved,  -1), 
 /* 5A */ new OpRec(Opcode.Reserved,  -1), 
 /* 5B */ new OpRec(Opcode.Reserved,  -1), 
 /* 5C */ new OpRec(Opcode.insqhi,  -1), 
 /* 5D */ new OpRec(Opcode.insqti,  -1), 
 /* 5E */ new OpRec(Opcode.remqhi,  -1), 
 /* 5F */ new OpRec(Opcode.remqti,  -1), 

 /* 60 */ new OpRec(Opcode.addd2,  "rd,rw"), 
 /* 61 */ new OpRec(Opcode.addd3,  "rd,rd,wd"), 
 /* 62 */ new OpRec(Opcode.subd2,  "rd,rw"), 
 /* 63 */ new OpRec(Opcode.subd3,  "rd,rd,wd"),  
 /* 64 */ new OpRec(Opcode.muld2,  "rd,rw"), 
 /* 65 */ new OpRec(Opcode.muld3,  "rd,rd,wd"),
 /* 66 */ new OpRec(Opcode.divd2,  "rd,rw"), 
 /* 67 */ new OpRec(Opcode.divd3,  "rd,rd,wd"),
 /* 68 */ new OpRec(Opcode.cvtdb,  "rd,rb"),  
 /* 69 */ new OpRec(Opcode.cvtdw,  "rd,rw"),  
 /* 6A */ new OpRec(Opcode.cvtdl,  "rd,rl"),  
 /* 6B */ new OpRec(Opcode.cvtrdl, "rd,rl"), 
 /* 6C */ new OpRec(Opcode.cvtbd,  "rb,rd"),
 /* 6D */ new OpRec(Opcode.cvtwd,  "rw,rd"),
 /* 6E */ new OpRec(Opcode.cvtld,  "rl,rd"),
 /* 6F */ new OpRec(Opcode.acbd,   "rd,rd,md,bw"),

 /* 70 */ new OpRec(Opcode.movd,  "rd,wd"), 
 /* 71 */ new OpRec(Opcode.cmpd,  "rd,rd"), 
 /* 72 */ new OpRec(Opcode.mnegd, "rd,wd"), 
 /* 73 */ new OpRec(Opcode.tstd,  "rd"), 
 /* 74 */ new OpRec(Opcode.emodd, "rd,rb,rd,wl,wd"), 
 /* 75 */ new OpRec(Opcode.polyd, "rd,rw,ab"), 
 /* 76 */ new OpRec(Opcode.cvtdf, "rd,wf"), 
 /* 77 */ new OpRec(Opcode.Reserved,  -1), 
 /* 78 */ new OpRec(Opcode.ashl, "rb,rl,wl"), 
 /* 79 */ new OpRec(Opcode.ashq, "rb,rq,wq"), 
 /* 7A */ new OpRec(Opcode.emul,  -1), 
 /* 7B */ new OpRec(Opcode.ediv,  -1), 
 /* 7C */ new OpRec(Opcode.clrq, "wq"), //  clrd,  clrg,  -1), 
 /* 7D */ new OpRec(Opcode.movq, "rq,wq"), 
 /* 7E */ new OpRec(Opcode.movaq, "aq,wl"), //  movad,  movag,  -1), 
 /* 7F */ new OpRec(Opcode.pushaq, "aq"), //  pushad,  pushag,  -1), 

 /* 80 */ new OpRec(Opcode.addb2, "rb,wb"), 
 /* 81 */ new OpRec(Opcode.addb3, "rb,rb,wb"), 
 /* 82 */ new OpRec(Opcode.subb2, "rb,wb"), 
 /* 83 */ new OpRec(Opcode.subb3, "rb,rb,wb"), 
 /* 84 */ new OpRec(Opcode.mulb2, "rb,rb"), 
 /* 85 */ new OpRec(Opcode.mulb3, "rb,rb,wb"), 
 /* 86 */ new OpRec(Opcode.divb2, "rb,rb"), 
 /* 87 */ new OpRec(Opcode.divb3, "rb,rb,wb"), 
 /* 88 */ new OpRec(Opcode.bisb2, "rb,rb"), 
 /* 89 */ new OpRec(Opcode.bisb3, "rb,rb,wb"), 
 /* 8A */ new OpRec(Opcode.bicb2, "rb,rb"), 
 /* 8B */ new OpRec(Opcode.bicb3, "rb,rb,wb"), 
 /* 8C */ new OpRec(Opcode.xorb2, "rb,wb"),  
 /* 8D */ new OpRec(Opcode.xorb3, "rb,rb,wb"),  
 /* 8E */ new OpRec(Opcode.mnegb, "rb,wb"), 
 /* 8F */ new OpRec(Opcode.caseb, "rb,rb,rb"),

 /* 90 */ new OpRec(Opcode.movb,  "rb,wb"), 
 /* 91 */ new OpRec(Opcode.cmpb,  "rb,rb"), 
 /* 92 */ new OpRec(Opcode.mcomb,  "rb,wb"), 
 /* 93 */ new OpRec(Opcode.bitb,  "rb,rb"), 
 /* 94 */ new OpRec(Opcode.clrb,  "wb"), 
 /* 95 */ new OpRec(Opcode.tstb,  "rb"), 
 /* 96 */ new OpRec(Opcode.incb,  "wb"), 
 /* 97 */ new OpRec(Opcode.decb,  "wb"), 
 /* 98 */ new OpRec(Opcode.cvtbl, "rb,wl"), 
 /* 99 */ new OpRec(Opcode.cvtbw, "rb,ww"), 
 /* 9A */ new OpRec(Opcode.movzbl, "rb,wl"), 
 /* 9B */ new OpRec(Opcode.movzbw, "rb,ww"),
 /* 9C */ new OpRec(Opcode.rotl,  "rb,rl,wl"),
 /* 9D */ new OpRec(Opcode.acbb,  "rb,rb,mb,bw"), 
 /* 9E */ new OpRec(Opcode.movab,  "ab,wl"), 
 /* 9F */ new OpRec(Opcode.pushab, "ab"), 

 /* A0 */ new OpRec(Opcode.addw2, "rw,ww"), 
 /* A1 */ new OpRec(Opcode.addw3, "rw,rw,ww"), 
 /* A2 */ new OpRec(Opcode.subw2, "rw,ww"), 
 /* A3 */ new OpRec(Opcode.subw3, "rw,rw,ww"), 
 /* A4 */ new OpRec(Opcode.mulw2, "rw,ww"), 
 /* A5 */ new OpRec(Opcode.mulw3, "rw,rw,ww"), 
 /* A6 */ new OpRec(Opcode.divw2, "rw,ww"), 
 /* A7 */ new OpRec(Opcode.divw3, "rw,rw,ww"), 
 /* A8 */ new OpRec(Opcode.bisw2, "rw,ww"), 
 /* A9 */ new OpRec(Opcode.bisw3, "rw,rw,ww"), 
 /* AA */ new OpRec(Opcode.bicw2, "rw,ww"), 
 /* AB */ new OpRec(Opcode.bicw3, "rw,rw,ww"), 
 /* AC */ new OpRec(Opcode.xorw2, "rw,ww"), 
 /* AD */ new OpRec(Opcode.xorw3, "rw,rw,ww"), 
 /* AE */ new OpRec(Opcode.mnegw, "rw,ww"),
 /* AF */ new OpRec(Opcode.casew,  -1), 

 /* B0 */ new OpRec(Opcode.movw, "rw,ww"), 
 /* B1 */ new OpRec(Opcode.cmpw, "rw,rw"),
 /* B2 */ new OpRec(Opcode.mcomw, "rw,ww"), 
 /* B3 */ new OpRec(Opcode.bitw, "rw,rw"),
 /* B4 */ new OpRec(Opcode.clrw,  "ww"), 
 /* B5 */ new OpRec(Opcode.tstw,  "rw"), 
 /* B6 */ new OpRec(Opcode.incw,  "ww"), 
 /* B7 */ new OpRec(Opcode.decw,  "ww"), 
 /* B8 */ new OpRec(Opcode.bispsw, "rw"), 
 /* B9 */ new OpRec(Opcode.bicpsw, "rw"), 
 /* BA */ new OpRec(Opcode.popr,  -1), 
 /* BB */ new OpRec(Opcode.pushr,  -1), 
 /* BC */ new OpRec(Opcode.chmk,  "rw"), 
 /* BD */ new OpRec(Opcode.chme,  "rw"), 
 /* BE */ new OpRec(Opcode.chms,  "rw"), 
 /* BF */ new OpRec(Opcode.chmu,  "rw"),
        
 /* C0 */ new OpRec(Opcode.addl2, "rl,wl"), 
 /* C1 */ new OpRec(Opcode.addl3, "rl,rl,wl"), 
 /* C2 */ new OpRec(Opcode.subl2, "rl,wl"),
 /* C3 */ new OpRec(Opcode.subl3, "rl,rl,wl"),
 /* C4 */ new OpRec(Opcode.mull2, "rl,wl"), 
 /* C5 */ new OpRec(Opcode.mull3, "rl,rl,wl"), 
 /* C6 */ new OpRec(Opcode.divl2, "rl,wl"),
 /* C7 */ new OpRec(Opcode.divl3, "rl,rl,wl"),
 /* C8 */ new OpRec(Opcode.bisl2, "rl,wl"),
 /* C9 */ new OpRec(Opcode.bisl3, "rl,rl,wl"),
 /* CA */ new OpRec(Opcode.bicl2, "rl,wl"),
 /* CB */ new OpRec(Opcode.bicl3, "rl,rl,wl"),
 /* CC */ new OpRec(Opcode.xorl2, "rl,wl"), 
 /* CD */ new OpRec(Opcode.xorl3, "rl,rl,wl"),
 /* CE */ new OpRec(Opcode.mnegl, "rl,wl"),
 /* CF */ new OpRec(Opcode.casel,  -1),
              
 /* D0 */ new OpRec(Opcode.movl, "rl,wl"), 
 /* D1 */ new OpRec(Opcode.cmpl, "rl,rl"), 
 /* D2 */ new OpRec(Opcode.mcoml, "rl,wl"),
 /* D3 */ new OpRec(Opcode.bitl, "rl,rl"),
 /* D4 */ new OpRec(Opcode.clrl, "wl"), //  clrf,  -1), 
 /* D5 */ new OpRec(Opcode.tstl, "rl"), 
 /* D6 */ new OpRec(Opcode.incl, "wl"), 
 /* D7 */ new OpRec(Opcode.decl, "wl"), 
 /* D8 */ new OpRec(Opcode.adwc, "rl,wl"),
 /* D9 */ new OpRec(Opcode.sbwc, "rl,ml"), 
 /* DA */ new OpRec(Opcode.mtpr,  -1), 
 /* DB */ new OpRec(Opcode.mfpr, "rl,wl"), 
 /* DC */ new OpRec(Opcode.movpsl,  -1), 
 /* DD */ new OpRec(Opcode.pushl, "rl"), 
 /* DE */ new OpRec(Opcode.moval, "al,wl"), // mova,  -1), 
 /* DF */ new OpRec(Opcode.pushal, "al"), // pushaf,  -1), 

 /* E0 */ new OpRec(Opcode.bbs, "rl,vb,bb"), 
 /* E1 */ new OpRec(Opcode.bbc, "rl,vb,bb"), 
 /* E2 */ new OpRec(Opcode.bbss, "rl,vb,bb"), 
 /* E3 */ new OpRec(Opcode.bbcs, "rl,vb,bb"), 
 /* E4 */ new OpRec(Opcode.bbsc, "rl,vb,bb"),
 /* E5 */ new OpRec(Opcode.bbcc, "rl,vb,bb"),
 /* E6 */ new OpRec(Opcode.bbssi, "rl,vb,bb"), 
 /* E7 */ new OpRec(Opcode.bbcci, "rl,vb,bb"),
 /* E8 */ new OpRec(Opcode.blbs,  "rl,bb"), 
 /* E9 */ new OpRec(Opcode.blbc,  "rl,bb"), 
 /* EA */ new OpRec(Opcode.ffs,  "rl,rb,vb,wl"), 
 /* EB */ new OpRec(Opcode.ffc,  "rl,rb,vb,wl"), 
 /* EC */ new OpRec(Opcode.cmpv,  -1), 
 /* ED */ new OpRec(Opcode.cmpzv,  -1), 
 /* EE */ new OpRec(Opcode.extv,  "rl,rb,vb,wl"),
 /* EF */ new OpRec(Opcode.extzv, "rl,rb,vb,wl"),

 /* F0 */ new OpRec(Opcode.insv,  -1), 
 /* F1 */ new OpRec(Opcode.acbl,   "rl,rl,ml,bw"),
 /* F2 */ new OpRec(Opcode.aoblss, "rl,ml,bb"), 
 /* F3 */ new OpRec(Opcode.aobleq, "rl,ml,bb"), 
 /* F4 */ new OpRec(Opcode.sobgeq, "ml,bb"),
 /* F5 */ new OpRec(Opcode.sobgtr, "ml,bb"),
 /* F6 */ new OpRec(Opcode.cvtlb, "rl,wb"), 
 /* F7 */ new OpRec(Opcode.cvtlw, "rl,ww"), 
 /* F8 */ new OpRec(Opcode.ashp,  "rb,rw,ab,rb,rw,ab"),
 /* F9 */ new OpRec(Opcode.cvtlp,  -1), 
 /* FA */ new OpRec(Opcode.callg,  -1), 
 /* FB */ new OpRec(Opcode.calls, "ab,ab"), 
 /* FC */ new OpRec(Opcode.xfc,  -1), 
 /* FD */ new OpRec(Opcode.Invalid, ""), // escd to Digital,  -1), 
 /* FE */ new OpRec(Opcode.Invalid, ""), // esce to Digital,  -1), 
 /* FF */ new OpRec(Opcode.Invalid, ""), // escf to Digital,  -1), 

            };
    }
}