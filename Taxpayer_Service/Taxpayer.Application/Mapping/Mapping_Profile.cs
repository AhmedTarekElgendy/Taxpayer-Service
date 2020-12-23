using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Taxpayer.Application.TaxpayerManagement.Commands;

namespace Taxpayer.Application.Mapping
{
    public class Mapping_Profile :Profile
    {
        public Mapping_Profile()
        {
             CreateMap<Taxpayer.Domain.Models.Taxpayer,TaxpayerCommand>();
            CreateMap<TaxpayerCommand, Taxpayer.Domain.Models.Taxpayer>();
        }
    }
}
