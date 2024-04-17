﻿namespace FrameworkDesign.Example
{
    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<GameStartEvent>();
        }
    }
}
