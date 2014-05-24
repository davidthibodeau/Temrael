using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataStructures
{
    public class Pair<T, K>
    {
        private T left;
        private K right;
        
        public Pair(T left, K right)
        {
            this.left = left;
            this.right = right;
        }

        public T Left { get { return left; } }
        public K Right { get { return right; } }
    }
}
