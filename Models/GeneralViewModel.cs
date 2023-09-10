using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ownpractice
{
    public class GeneralViewModelList
    {
        public List<GeneralViewModel> generalViewModels{get;set;}
    }


    public class GeneralViewModel
    {
        public string Name{get;set;}
        public string kpId{get;set;}
    }
}