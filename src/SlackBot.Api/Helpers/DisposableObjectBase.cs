using System;

namespace SlackBot.Api.Helpers
{
	public abstract class DisposableObjectBase : IDisposable
	{
		private bool _disposed;
        
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected abstract void DisposeObjects();

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					DisposeObjects();
				}
                
				_disposed = true;
			}
		}
	}
}