using Microsoft.AspNetCore.Components;

namespace BlazorMediatr.Features
{
    public class MediatrDecorator: IMediator
    {
        private readonly IMediator _mediator;
        private ILogger _logger;
        private readonly NavigationManager _navigationManager;
        public MediatrDecorator(IMediator mediator, ILogger<MediatrDecorator> logger, NavigationManager navigationManager)
        {
            _mediator = mediator;
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                //handle exception;
                _logger.LogError(ex, "Fatal Error");
                _navigationManager.NavigateTo("/customerror");
                return default(TResponse);
            }

           
            

        }

        public async Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response;
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var response = _mediator.CreateStream(request, cancellationToken);
            return response;
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            var response = _mediator.CreateStream(request, cancellationToken);
            return response;
        }

        public async Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(notification, cancellationToken);
            return;
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            await _mediator.Publish<TNotification>(notification, cancellationToken);
            return;
        }


    }
}
