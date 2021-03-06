using System;

namespace Infrastructure.Services.Coroutines
{
    public interface IAwaiter
    {
        #region Methods

        IAwaiter OnStart(Action callback);
        IAwaiter OnEnd(Action callback);
        IAwaiter OnProgress(Action<float> callback);
        void Start();
        void End();
        void Progress(float param);

        #endregion
    }
}