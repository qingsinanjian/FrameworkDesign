﻿using FrameworkDesign;

namespace Counter
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value--;
        }
    }
}
