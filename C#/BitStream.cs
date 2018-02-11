using System;

namespace Excessives.BitStream
{
    //{TODO} Test this properly
    struct BitStream
    {
        public byte[] stream;

        public long length
        {
            get
            {
                return stream.LongLength * 8;
            }
        }

        public BitStream(byte[] stream)
        {
            this.stream = stream;
        }

        public bool this[ulong index]
        {
            //{TODO} FINISH!
            get
            {
                return
                    (stream[(ulong)Math.Floor((double)index / 8.0)]
                    & (1 << (int)(index % 7))
                    ) > 0;
            }
            set
            {
                if (value)
                {
                    stream[(ulong)Math.Floor((double)index / 8.0)]
                    |=
                  (byte)(1 << (int)(index % 7))//Turn the bit on
                  ;
                }
                else
                {
                    stream[(ulong)Math.Floor((double)index / 8.0)]
                   |=
                 (byte)(1 << (int)(index % 7))//Turn the bit on
                 ;

                    stream[(ulong)Math.Floor((double)index / 8.0)]
                 ^=
               (byte)(1 << (int)(index % 7))//Toggle the bit (Toggle from on -> off)
               ;
                }
            }
        }


    }
}
