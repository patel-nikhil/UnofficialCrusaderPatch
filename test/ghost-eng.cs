            new Change("u_ghosteng", ChangeType.Bugfix, true)
            {
                new DefaultHeader("u_ghosteng")
                {
                    new BinaryEdit("u_ghostengineer")
                    {
                        //new BinBytes(new byte[]{0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xC3}),
                        //bytes for call location are offset from next instruction to destination
                        new BinAddress("fcn", 0xA, true),

                        //new BinSkip(0x1B),
                        new BinHook(0xE)
                        {

                            new BinBytes(new byte[]{
                                
                                /* pusha */
                                0x60,

                                /* lea edi,[edi+esi*1+0x618] */
                                0x8D, 0xBC, 0x37, 0x18, 0x06, 0x00, 0x00,

                                /*xor eax,eax */
                                0x31, 0xC0,

                                /* mov al,BYTE PTR [edi+0x8a] */
                                0x8A, 0x87, 0x8A, 0x00, 0x00, 0x00,

                                /* cmp al,0x27 */
                                0x3C, 0x27,

                                /* je <continue> */
                                0x74, 0x1E,

                                /* cmp al,0x28 */
                                0x3C, 0x28,

                                /* je <continue> */
                                0x74, 0x1A,

                                /* cmp al,0x29 */
                                0x3C, 0x29,

                                /* je <continue> */
                                0x74, 0x16,

                                /* cmp al, 0x3A */
                                0x3C, 0x3A,

                                /* je <continue> */
                                0x74, 0x12,

                                /* cmp al,0x3B */
                                0x3C, 0x3B,

                                /* je <continue> */
                                0x74, 0x0E,

                                /* cmp al,0x3C */
                                0x3C, 0x3C,

                                /* je <continue> */
                                0x74, 0xA,

                                /* cmp al,0x3D */
                                0x3C, 0x3D,

                                /* je <continue> */
                                0x74, 0x06,

                                /* cmp al,0x4D */
                                0x3C, 0x4D,

                                /* je <continue> */
                                0x74, 0x02,

                                /* jmp <end> */
                                0xEB, 0x40,

                                /* <continue> */

                                /* lea esi,[edi+0x3b0] */
                                0x8D, 0xB7, 0xB0, 0x03, 0x00, 0x00,

                                /*xor eax,eax */
                                0x31, 0xC0,

                                /* mov al,BYTE PTR [esi] */
                                0x8A, 0x06,
                            }),

                            /* loop1 */

                            new BinBytes(new byte[]
                            {
                                /* cmp eax,0x0 */
                                0x83, 0xF8, 0x00,
                            }),

                            /* je <end> */
                            0x74, 0x31,

                            //0x0F, 0x84, new BinRefTo("end"),

                            new BinBytes(new byte[]
                            {
                                /* lea ebx,[edi+eax*2+0x32d] */
                                0x8D, 0x9C, 0x47, 0x0E, 0x03, 0x00, 0x00,

                                /* xor ecx,ecx */
                                0x31, 0xC9,

                                /* mov cl, byte ptr [ebx] */
                                0x8A, 0x0B,

                                /* imul ecx,ecx,0x490 */
                                0x69, 0xC9, 0x90, 0x04, 0x00, 0x00,

                                /* lea edx,[ecx+0x145d040] */
                                0x8D, 0x91, 0x40, 0xD0, 0x45, 0x01,

                                /* push eax */
                                0x50,

                                /*xor eax,eax */
                                0x31, 0xC0,
                            }),

                            /* loop2 */
                            //new BinAddress("loop2", 0x0, true),

                            new BinBytes(new byte[]
                            {
                                /* mov DWORD PTR [edx+eax*1],0x0 */
                                0xc7, 0x04, 0x02, 0x00, 0x00, 0x00, 0x00,

                                /* add eax,0x4 */
                                0x83, 0xc0, 0x04,

                                /* cmp eax,0x490 */
                                0x3D, 0x90, 0x04, 0x00, 0x00,
                            }),

                            /* jl <loop2> */
                            0x7C, 0xEF,
                            //0x0F, 0x8C, new BinRefTo("loop2"),

                            /* pop eax */
                            0x58,

                            /* sub eax, 0x1*/
                            0x83, 0xE8, 0x01,

                            /* jmp <loop1> */
                            0xEB, 0xCA,
                            //0x0F, 0x84, new BinRefTo("loop1", true),

                            /* <end> */

                            //new BinAddress("end", 0x4, true),
                            new BinBytes(new byte[]
                            {
                                /* popa */
                                0x61
                            }),

                            new BinBytes(new CodeBlox.CodeBlock(Assembly.GetExecutingAssembly().GetManifestResourceStream("UCP.CodeBlocks.u_ghostengineer.block")).Elements.ToArray().Select(x => x.Value).ToArray()),

                            new BinRefTo("fcn"),
                        }
                    }
                }
            },