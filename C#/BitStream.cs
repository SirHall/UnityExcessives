using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excessives;

namespace Excessives.BitStream
{
    /*   public class Program//Just to test!
       {
           public void Main(string[] args)
           {
               BitStream stream = new BitStream(BitConverter.GetBytes(12372891739));


               for (long i = 0; i < stream.length; i++)
               {
                   Console.Write(stream[(ulong)i] ? "1" : "0");
               }

               Console.ReadKey();
           }
       }*/
    //{TODO} Test this properly
    struct BitStream
    {
        byte[] stream;

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
