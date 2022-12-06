using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace Infrastructure.Bogus
{
    public static class DataBogus
    {

        public static  IList<po_info_bogus> AddBogusPoInfo(int count)
        {
            Faker<po_info_bogus> faker = new Faker<po_info_bogus>()
                .StrictMode(false)
                .RuleFor(x => x.项目号, f => f.Finance.Account(8))
                .RuleFor(x => x.工单号, f => f.Finance.Account(8))
                .RuleFor(x => x.工单数量, f => f.Random.Int(0,30))
                .RuleFor(x => x.图号, f => f.Commerce.ProductName())
                .RuleFor(x => x.产成品名称, f => f.Commerce.ProductName())
                .RuleFor(x => x.线上数量, f => f.Random.Int(0, 300))
                 .RuleFor(x => x.已完工数量, f => f.Random.Int(0, 300))
                  .RuleFor(x => x.创建时间, f => f.Date.Recent(10))
                    .RuleFor(x => x.创建人员, f => f.Name.FindName())
                    .RuleFor(x => x.开工日期, f => f.Date.Recent(10))
                     .RuleFor(x => x.计划完工日期, f => f.Date.Recent(10))
                      .RuleFor(x => x.实际完工日期, f => f.Date.Recent(10))
                       .RuleFor(x => x.工单状态, f => f.Address.State())
                       
                       .RuleFor(x => x.工位利用率, f => f.Address.State());

            var res =faker.Generate(count);
            return res;




        }
    }
}
