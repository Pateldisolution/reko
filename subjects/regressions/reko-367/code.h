// code.h
// Generated by decompiling code.bin
// using Reko decompiler version 0.8.0.2.

/*
// Equivalence classes ////////////
Eq_1: (struct "Globals" (800004FC Eq_11 t800004FC) (80000508 Eq_26 t80000508) (80000514 real96 r80000514) (80000520 Eq_76 t80000520) (8000052C real96 r8000052C) (80000538 Eq_9 t80000538))
	globals_t (in globals : (ptr32 (struct "Globals")))
Eq_3: (fn void (word32))
	T_3 (in fn800003CC : ptr32)
	T_4 (in signature of fn800003CC : void)
Eq_9: (union "Eq_9" (real96 u0) (word32 u1))
	T_9 (in rArg04 : Eq_9)
	T_10 (in rArg10 : Eq_9)
	T_21 (in (real96) dwLoc14_59 : real96)
	T_25 (in rArg04 : Eq_9)
	T_38 (in (real96) dwLoc14_59 : real96)
	T_42 (in rArg04 : Eq_9)
	T_43 (in dwLoc08_117 : Eq_9)
	T_53 (in (real96) dwLoc20_113 : real96)
	T_59 (in (real96) dwLoc20_113 : real96)
	T_68 (in SEQ(dwLoc08_117, dwLoc08_117, dwLoc08_117) + (real80) fp0_94 : real96)
	T_75 (in rArg04 : Eq_9)
	T_87 (in (real96) dwLoc20_112 : real96)
	T_92 (in (real96) dwLoc20_112 : real96)
	T_107 (in rArg04 : Eq_9)
	T_114 (in fp0_8 : Eq_9)
	T_116 (in Mem5[0x80000538:real96] : real96)
Eq_11: (union "Eq_11" (real96 u0) (word32 u1))
	T_11 (in dwLoc08_64 : Eq_11)
	T_13 (in Mem11[0x800004FC:real96] : real96)
	T_18 (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) * rArg04 : real96)
Eq_26: (union "Eq_26" (real96 u0) (word32 u1))
	T_26 (in dwLoc08_64 : Eq_26)
	T_28 (in Mem11[0x80000508:real96] : real96)
	T_35 (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) * (real80) ((real96) dwLoc14_59) : real96)
Eq_34: (union "Eq_34" (real80 u0) (real96 u1))
	T_34 (in (real80) (real96) dwLoc14_59 : real80)
Eq_51: (fn real96 (word32, Eq_9, Eq_9))
	T_51 (in fn80000132 : ptr32)
	T_52 (in signature of fn80000132 : void)
	T_86 (in fn80000132 : ptr32)
	T_117 (in fn80000132 : ptr32)
Eq_57: (fn real96 (word32, Eq_9))
	T_57 (in fn8000018E : ptr32)
	T_58 (in signature of fn8000018E : void)
	T_91 (in fn8000018E : ptr32)
	T_119 (in fn8000018E : ptr32)
Eq_61: (union "Eq_61" (real80 u0) (real96 u1))
	T_61 (in (real80) fn8000018E(d2, (real96) dwLoc20_113) : real80)
Eq_67: (union "Eq_67" (real80 u0) (real96 u1))
	T_67 (in (real80) fp0_94 : real80)
Eq_76: (union "Eq_76" (real96 u0) (word32 u1))
	T_76 (in dwLoc08_116 : Eq_76)
	T_78 (in Mem14[0x80000520:real96] : real96)
	T_101 (in SEQ(dwLoc08_116, dwLoc08_116, dwLoc08_116) + (real80) fp0_94 : real96)
Eq_94: (union "Eq_94" (real80 u0) (real96 u1))
	T_94 (in (real80) fn8000018E(d2, (real96) dwLoc20_112) : real80)
Eq_100: (union "Eq_100" (real80 u0) (real96 u1))
	T_100 (in (real80) fp0_94 : real80)
Eq_108: (fn real96 (word32, Eq_9))
	T_108 (in fn800001F2 : ptr32)
	T_109 (in signature of fn800001F2 : void)
	T_121 (in fn800001F2 : ptr32)
Eq_111: (fn real96 (word32, Eq_9))
	T_111 (in fn800002AE : ptr32)
	T_112 (in signature of fn800002AE : void)
	T_123 (in fn800002AE : ptr32)
Eq_125: (fn void (word32, Eq_9))
	T_125 (in fn8000036C : ptr32)
	T_126 (in signature of fn8000036C : void)
// Type Variables ////////////
globals_t: (in globals : (ptr32 (struct "Globals")))
  Class: Eq_1
  DataType: (ptr32 Eq_1)
  OrigDataType: (ptr32 (struct "Globals"))
T_2: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_3: (in fn800003CC : ptr32)
  Class: Eq_3
  DataType: (ptr32 Eq_3)
  OrigDataType: (ptr32 (fn T_6 (T_2)))
T_4: (in signature of fn800003CC : void)
  Class: Eq_3
  DataType: (ptr32 Eq_3)
  OrigDataType: 
T_5: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_6: (in fn800003CC(d2) : void)
  Class: Eq_6
  DataType: void
  OrigDataType: void
T_7: (in fp0 : real96)
  Class: Eq_7
  DataType: real96
  OrigDataType: real96
T_8: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_9: (in rArg04 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_10: (in rArg10 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_11: (in dwLoc08_64 : Eq_11)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: (union (real96 u0) (word32 u1))
T_12: (in 800004FC : ptr32)
  Class: Eq_12
  DataType: (ptr32 Eq_11)
  OrigDataType: (ptr32 (struct (0 T_13 t0000)))
T_13: (in Mem11[0x800004FC:real96] : real96)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: real96
T_14: (in dwLoc14_59 : word32)
  Class: Eq_14
  DataType: word32
  OrigDataType: word32
T_15: (in 0x00000000 : word32)
  Class: Eq_14
  DataType: word32
  OrigDataType: word32
T_16: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) : real96)
  Class: Eq_7
  DataType: real96
  OrigDataType: real96
T_17: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) : real96)
  Class: Eq_17
  DataType: real96
  OrigDataType: real96
T_18: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) * rArg04 : real96)
  Class: Eq_11
  DataType: Eq_11
  OrigDataType: real96
T_19: (in 0x00000001 : word32)
  Class: Eq_19
  DataType: word32
  OrigDataType: word32
T_20: (in dwLoc14_59 + 0x00000001 : word32)
  Class: Eq_14
  DataType: word32
  OrigDataType: word32
T_21: (in (real96) dwLoc14_59 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_22: (in (real96) dwLoc14_59 >= rArg10 : bool)
  Class: Eq_22
  DataType: bool
  OrigDataType: bool
T_23: (in fp0 : real96)
  Class: Eq_23
  DataType: real96
  OrigDataType: real96
T_24: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_25: (in rArg04 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_26: (in dwLoc08_64 : Eq_26)
  Class: Eq_26
  DataType: Eq_26
  OrigDataType: (union (real96 u0) (word32 u1))
T_27: (in 80000508 : ptr32)
  Class: Eq_27
  DataType: (ptr32 Eq_26)
  OrigDataType: (ptr32 (struct (0 T_28 t0000)))
T_28: (in Mem11[0x80000508:real96] : real96)
  Class: Eq_26
  DataType: Eq_26
  OrigDataType: real96
T_29: (in dwLoc14_59 : int32)
  Class: Eq_29
  DataType: int32
  OrigDataType: int32
T_30: (in 1 : int32)
  Class: Eq_29
  DataType: int32
  OrigDataType: int32
T_31: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) : real96)
  Class: Eq_23
  DataType: real96
  OrigDataType: real96
T_32: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) : real96)
  Class: Eq_32
  DataType: real96
  OrigDataType: real96
T_33: (in (real96) dwLoc14_59 : real96)
  Class: Eq_33
  DataType: real96
  OrigDataType: real96
T_34: (in (real80) (real96) dwLoc14_59 : real80)
  Class: Eq_34
  DataType: Eq_34
  OrigDataType: (union (real80 u0) (real96 u1))
T_35: (in SEQ(dwLoc08_64, dwLoc08_64, dwLoc08_64) * (real80) ((real96) dwLoc14_59) : real96)
  Class: Eq_26
  DataType: Eq_26
  OrigDataType: real96
T_36: (in 0x00000001 : word32)
  Class: Eq_36
  DataType: word32
  OrigDataType: word32
T_37: (in dwLoc14_59 + 0x00000001 : word32)
  Class: Eq_29
  DataType: int32
  OrigDataType: int32
T_38: (in (real96) dwLoc14_59 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_39: (in (real96) dwLoc14_59 > rArg04 : bool)
  Class: Eq_39
  DataType: bool
  OrigDataType: bool
T_40: (in fp0 : real96)
  Class: Eq_40
  DataType: real96
  OrigDataType: real96
T_41: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_42: (in rArg04 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_43: (in dwLoc08_117 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: (union (real96 u0) (word32 u1))
T_44: (in rLoc1C_112 : real96)
  Class: Eq_44
  DataType: real96
  OrigDataType: real96
T_45: (in 80000514 : ptr32)
  Class: Eq_45
  DataType: (ptr32 real96)
  OrigDataType: (ptr32 (struct (0 T_46 t0000)))
T_46: (in Mem17[0x80000514:real96] : real96)
  Class: Eq_44
  DataType: real96
  OrigDataType: real96
T_47: (in dwLoc20_113 : int32)
  Class: Eq_47
  DataType: int32
  OrigDataType: int32
T_48: (in 3 : int32)
  Class: Eq_47
  DataType: int32
  OrigDataType: int32
T_49: (in SEQ(dwLoc08_117, dwLoc08_117, dwLoc08_117) : real96)
  Class: Eq_40
  DataType: real96
  OrigDataType: real96
T_50: (in fp0_94 : real96)
  Class: Eq_44
  DataType: real96
  OrigDataType: real96
T_51: (in fn80000132 : ptr32)
  Class: Eq_51
  DataType: (ptr32 Eq_51)
  OrigDataType: (ptr32 (fn T_54 (T_41, T_42, T_53)))
T_52: (in signature of fn80000132 : void)
  Class: Eq_51
  DataType: (ptr32 Eq_51)
  OrigDataType: 
T_53: (in (real96) dwLoc20_113 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_54: (in fn80000132(d2, rArg04, (real96) dwLoc20_113) : real96)
  Class: Eq_54
  DataType: real96
  OrigDataType: real96
T_55: (in (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) : real80)
  Class: Eq_55
  DataType: real80
  OrigDataType: real80
T_56: (in (real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) : real96)
  Class: Eq_56
  DataType: real96
  OrigDataType: real96
T_57: (in fn8000018E : ptr32)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: (ptr32 (fn T_60 (T_41, T_59)))
T_58: (in signature of fn8000018E : void)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: 
T_59: (in (real96) dwLoc20_113 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_60: (in fn8000018E(d2, (real96) dwLoc20_113) : real96)
  Class: Eq_60
  DataType: real96
  OrigDataType: real96
T_61: (in (real80) fn8000018E(d2, (real96) dwLoc20_113) : real80)
  Class: Eq_61
  DataType: Eq_61
  OrigDataType: (union (real80 u0) (real96 u1))
T_62: (in (real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) / (real80) fn8000018E(d2, (real96) dwLoc20_113) : real96)
  Class: Eq_62
  DataType: real96
  OrigDataType: real96
T_63: (in (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) / (real80) fn8000018E(d2, (real96) dwLoc20_113)) : real80)
  Class: Eq_63
  DataType: real80
  OrigDataType: real80
T_64: (in (real96) (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) / (real80) fn8000018E(d2, (real96) dwLoc20_113)) : real96)
  Class: Eq_64
  DataType: real96
  OrigDataType: real96
T_65: (in (real96) (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_113) / (real80) fn8000018E(d2, (real96) dwLoc20_113)) * rLoc1C_112 : real96)
  Class: Eq_44
  DataType: real96
  OrigDataType: real96
T_66: (in SEQ(dwLoc08_117, dwLoc08_117, dwLoc08_117) : real96)
  Class: Eq_66
  DataType: real96
  OrigDataType: real96
T_67: (in (real80) fp0_94 : real80)
  Class: Eq_67
  DataType: Eq_67
  OrigDataType: (union (real80 u0) (real96 u1))
T_68: (in SEQ(dwLoc08_117, dwLoc08_117, dwLoc08_117) + (real80) fp0_94 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_69: (in 0x00000002 : word32)
  Class: Eq_69
  DataType: word32
  OrigDataType: word32
T_70: (in dwLoc20_113 + 0x00000002 : word32)
  Class: Eq_47
  DataType: int32
  OrigDataType: int32
T_71: (in 100 : int32)
  Class: Eq_47
  DataType: int32
  OrigDataType: int32
T_72: (in dwLoc20_113 > 100 : bool)
  Class: Eq_72
  DataType: bool
  OrigDataType: bool
T_73: (in fp0 : real96)
  Class: Eq_73
  DataType: real96
  OrigDataType: real96
T_74: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_75: (in rArg04 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_76: (in dwLoc08_116 : Eq_76)
  Class: Eq_76
  DataType: Eq_76
  OrigDataType: (union (real96 u0) (word32 u1))
T_77: (in 80000520 : ptr32)
  Class: Eq_77
  DataType: (ptr32 Eq_76)
  OrigDataType: (ptr32 (struct (0 T_78 t0000)))
T_78: (in Mem14[0x80000520:real96] : real96)
  Class: Eq_76
  DataType: Eq_76
  OrigDataType: real96
T_79: (in rLoc1C_111 : real96)
  Class: Eq_79
  DataType: real96
  OrigDataType: real96
T_80: (in 8000052C : ptr32)
  Class: Eq_80
  DataType: (ptr32 real96)
  OrigDataType: (ptr32 (struct (0 T_81 t0000)))
T_81: (in Mem17[0x8000052C:real96] : real96)
  Class: Eq_79
  DataType: real96
  OrigDataType: real96
T_82: (in dwLoc20_112 : int32)
  Class: Eq_82
  DataType: int32
  OrigDataType: int32
T_83: (in 2 : int32)
  Class: Eq_82
  DataType: int32
  OrigDataType: int32
T_84: (in SEQ(dwLoc08_116, dwLoc08_116, dwLoc08_116) : real96)
  Class: Eq_73
  DataType: real96
  OrigDataType: real96
T_85: (in fp0_94 : real96)
  Class: Eq_79
  DataType: real96
  OrigDataType: real96
T_86: (in fn80000132 : ptr32)
  Class: Eq_51
  DataType: (ptr32 Eq_51)
  OrigDataType: (ptr32 (fn T_88 (T_74, T_75, T_87)))
T_87: (in (real96) dwLoc20_112 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_88: (in fn80000132(d2, rArg04, (real96) dwLoc20_112) : real96)
  Class: Eq_54
  DataType: real96
  OrigDataType: real96
T_89: (in (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) : real80)
  Class: Eq_89
  DataType: real80
  OrigDataType: real80
T_90: (in (real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) : real96)
  Class: Eq_90
  DataType: real96
  OrigDataType: real96
T_91: (in fn8000018E : ptr32)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: (ptr32 (fn T_93 (T_74, T_92)))
T_92: (in (real96) dwLoc20_112 : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_93: (in fn8000018E(d2, (real96) dwLoc20_112) : real96)
  Class: Eq_60
  DataType: real96
  OrigDataType: real96
T_94: (in (real80) fn8000018E(d2, (real96) dwLoc20_112) : real80)
  Class: Eq_94
  DataType: Eq_94
  OrigDataType: (union (real80 u0) (real96 u1))
T_95: (in (real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) / (real80) fn8000018E(d2, (real96) dwLoc20_112) : real96)
  Class: Eq_95
  DataType: real96
  OrigDataType: real96
T_96: (in (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) / (real80) fn8000018E(d2, (real96) dwLoc20_112)) : real80)
  Class: Eq_96
  DataType: real80
  OrigDataType: real80
T_97: (in (real96) (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) / (real80) fn8000018E(d2, (real96) dwLoc20_112)) : real96)
  Class: Eq_97
  DataType: real96
  OrigDataType: real96
T_98: (in (real96) (real80) ((real96) (real80) fn80000132(d2, rArg04, (real96) dwLoc20_112) / (real80) fn8000018E(d2, (real96) dwLoc20_112)) * rLoc1C_111 : real96)
  Class: Eq_79
  DataType: real96
  OrigDataType: real96
T_99: (in SEQ(dwLoc08_116, dwLoc08_116, dwLoc08_116) : real96)
  Class: Eq_99
  DataType: real96
  OrigDataType: real96
T_100: (in (real80) fp0_94 : real80)
  Class: Eq_100
  DataType: Eq_100
  OrigDataType: (union (real80 u0) (real96 u1))
T_101: (in SEQ(dwLoc08_116, dwLoc08_116, dwLoc08_116) + (real80) fp0_94 : real96)
  Class: Eq_76
  DataType: Eq_76
  OrigDataType: real96
T_102: (in 0x00000002 : word32)
  Class: Eq_102
  DataType: word32
  OrigDataType: word32
T_103: (in dwLoc20_112 + 0x00000002 : word32)
  Class: Eq_82
  DataType: int32
  OrigDataType: int32
T_104: (in 100 : int32)
  Class: Eq_82
  DataType: int32
  OrigDataType: int32
T_105: (in dwLoc20_112 > 100 : bool)
  Class: Eq_105
  DataType: bool
  OrigDataType: bool
T_106: (in d2 : word32)
  Class: Eq_2
  DataType: word32
  OrigDataType: word32
T_107: (in rArg04 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_108: (in fn800001F2 : ptr32)
  Class: Eq_108
  DataType: (ptr32 Eq_108)
  OrigDataType: (ptr32 (fn T_110 (T_106, T_107)))
T_109: (in signature of fn800001F2 : void)
  Class: Eq_108
  DataType: (ptr32 Eq_108)
  OrigDataType: 
T_110: (in fn800001F2(d2, rArg04) : real96)
  Class: Eq_110
  DataType: real96
  OrigDataType: real96
T_111: (in fn800002AE : ptr32)
  Class: Eq_111
  DataType: (ptr32 Eq_111)
  OrigDataType: (ptr32 (fn T_113 (T_106, T_107)))
T_112: (in signature of fn800002AE : void)
  Class: Eq_111
  DataType: (ptr32 Eq_111)
  OrigDataType: 
T_113: (in fn800002AE(d2, rArg04) : real96)
  Class: Eq_113
  DataType: real96
  OrigDataType: real96
T_114: (in fp0_8 : Eq_9)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_115: (in 80000538 : ptr32)
  Class: Eq_115
  DataType: (ptr32 Eq_9)
  OrigDataType: (ptr32 (struct (0 T_116 t0000)))
T_116: (in Mem5[0x80000538:real96] : real96)
  Class: Eq_9
  DataType: Eq_9
  OrigDataType: real96
T_117: (in fn80000132 : ptr32)
  Class: Eq_51
  DataType: (ptr32 Eq_51)
  OrigDataType: (ptr32 (fn T_118 (T_5, T_114, T_114)))
T_118: (in fn80000132(d2, fp0_8, fp0_8) : real96)
  Class: Eq_54
  DataType: real96
  OrigDataType: real96
T_119: (in fn8000018E : ptr32)
  Class: Eq_57
  DataType: (ptr32 Eq_57)
  OrigDataType: (ptr32 (fn T_120 (T_5, T_114)))
T_120: (in fn8000018E(d2, fp0_8) : real96)
  Class: Eq_60
  DataType: real96
  OrigDataType: real96
T_121: (in fn800001F2 : ptr32)
  Class: Eq_108
  DataType: (ptr32 Eq_108)
  OrigDataType: (ptr32 (fn T_122 (T_5, T_114)))
T_122: (in fn800001F2(d2, fp0_8) : real96)
  Class: Eq_110
  DataType: real96
  OrigDataType: real96
T_123: (in fn800002AE : ptr32)
  Class: Eq_111
  DataType: (ptr32 Eq_111)
  OrigDataType: (ptr32 (fn T_124 (T_5, T_114)))
T_124: (in fn800002AE(d2, fp0_8) : real96)
  Class: Eq_113
  DataType: real96
  OrigDataType: real96
T_125: (in fn8000036C : ptr32)
  Class: Eq_125
  DataType: (ptr32 Eq_125)
  OrigDataType: (ptr32 (fn T_127 (T_5, T_114)))
T_126: (in signature of fn8000036C : void)
  Class: Eq_125
  DataType: (ptr32 Eq_125)
  OrigDataType: 
T_127: (in fn8000036C(d2, fp0_8) : void)
  Class: Eq_127
  DataType: void
  OrigDataType: void
*/
typedef struct Globals {
	Eq_11 t800004FC;	// 800004FC
	Eq_26 t80000508;	// 80000508
	real96 r80000514;	// 80000514
	Eq_76 t80000520;	// 80000520
	real96 r8000052C;	// 8000052C
	Eq_9 t80000538;	// 80000538
} Eq_1;

typedef void (Eq_3)(word32);

typedef union Eq_9 {
	real96 u0;
	word32 u1;
} Eq_9;

typedef union Eq_11 {
	real96 u0;
	word32 u1;
} Eq_11;

typedef union Eq_26 {
	real96 u0;
	word32 u1;
} Eq_26;

typedef union Eq_34 {
	real80 u0;
	real96 u1;
} Eq_34;

typedef real96 (Eq_51)(word32, Eq_9, Eq_9);

typedef real96 (Eq_57)(word32, Eq_9);

typedef union Eq_61 {
	real80 u0;
	real96 u1;
} Eq_61;

typedef union Eq_67 {
	real80 u0;
	real96 u1;
} Eq_67;

typedef union Eq_76 {
	real96 u0;
	word32 u1;
} Eq_76;

typedef union Eq_94 {
	real80 u0;
	real96 u1;
} Eq_94;

typedef union Eq_100 {
	real80 u0;
	real96 u1;
} Eq_100;

typedef real96 (Eq_108)(word32, Eq_9);

typedef real96 (Eq_111)(word32, Eq_9);

typedef void (Eq_125)(word32, Eq_9);

