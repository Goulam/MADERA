﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Model;
using Web_Service.Entity;

namespace Web_Service.Controller
{
    public class GammesBLL : GammesDAO
    {
        public List<GammesEntity> selectAllGames()
        {
            return selectAllGamme();
        }
    }
}
