using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ownpractice.Entities
{
    public class _Movie
    {
        public int _MovieId{get;set;}
        public string Name{get;set;}
        public string kpId{get;set;}
        // 0 = not index, 1 = liked, 2 = disliked, 3 = watch in future
        public int userIndex{get;set;}
    }
}