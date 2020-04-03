using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int Capacity => capacity;
        public int Occupied => vehicles.Count();
        public int Free => vehicles.Count(s => s == null);

        private readonly int capacity;

        private readonly T[] vehicles;

        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            vehicles = new T[this.capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if (item != null)
                {
                    yield return item;
                }
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

        internal bool Park(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return true;
                }

            }
            return false;
        }

        internal void List()
        {
   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
