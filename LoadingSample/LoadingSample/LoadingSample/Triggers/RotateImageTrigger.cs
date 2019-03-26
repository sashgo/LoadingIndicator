using System;
using LoadingSample.Enums;
using LoadingSample.Models;
using Xamarin.Forms;

namespace LoadingSample.Triggers
{
    public class RotateImageTrigger : TriggerAction<Image>
    {
        public RotateImageTrigger()
        {
        }

        #region --Overrides--

        protected override async void Invoke(Image sender)
        {
            var loadChainModel = (LoadChainModel)sender.BindingContext;
            while (loadChainModel.State == ELoadState.Run)
            {
                await sender.RelRotateTo(360, 500);
            }

            sender.Rotation = 0;
        }

        #endregion
    }
}
