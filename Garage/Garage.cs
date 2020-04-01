using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int Capacity => capacity;
        private readonly int capacity;

        private T[] vehicles;

        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            vehicles = new T[this.capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }
        }

        internal bool Leave(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == vehicle)
                {
                    vehicles[i] = null;
                    return true;
                }

            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //private int capacity;
        //public int Capacity => capacity;
        //public Garage(int capacity)
        //{
        //    this.capacity = Math.Max(0, capacity);
        //    GarageList = new List<T>(this.capacity);
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
