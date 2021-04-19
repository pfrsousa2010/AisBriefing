﻿using Core.Business;
using Core.Databases;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class EditLocationViewModel : BaseEditItemViewModel<Location, LocationBusiness, BaseManager<Location>>
    {
    }
}