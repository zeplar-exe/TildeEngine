## Long-running operations

- Long-running tasks like playing audio or video should be wrapped into a class containing the following methods:
> async Task Start(..., CancellationToken token)
>
> Begins the task asynchronously and stores the CancellationToken

> void Pause()
>
> Pauses the task without cancelling it, throws a relevant exception if the operation has not started.

> void Cancel()
>
> Invokes the CancellationToken which should have been stored internally, throws a relevant exception if the operation has not started.

> async Task Restart(..., CancellationToken token)
>
> Resets any state-changing variables and calls Start(..., token)
- Long-running task wrappers should store a cancellation token passed from the Start/Restart methods internally