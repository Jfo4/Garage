using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public Garage()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
