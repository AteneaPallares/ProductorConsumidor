using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor
{
    class Semaphore
    {
        private int _flag;
        public int flag { set { _flag = value; } get { return _flag; } }
        public bool available;
        public int products;
        public int[] wait = { 1, 1 };

        public Semaphore()
        {
            _flag = 1;
            available = true;
            products = 0;
        }

        public void Reset()
        {
            wait[0] = 1;
            wait[1] = 1;
            _flag = 1;
            available = true;
            products = 0;
        }

        public void SemWait(int k)
        {
            if (_flag == 1)
            {
                wait[k] = 1;
                _flag = 0;
            }
            else
            {
                wait[k] = 0;
            }
        }

        public void SemSignal(int k)
        {
            if (k == 0)
            {
                if (wait[1] == 0)
                {
                    wait[1] = 1;
                }
                else
                {
                    _flag = 1;
                }
            }
            else
            {
                if (wait[0] == 0)
                {
                    wait[0] = 1;
                }
                else
                {
                    _flag = 1;
                }
            }
        }
    }
}
