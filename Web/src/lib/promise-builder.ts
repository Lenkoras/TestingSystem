import { Observable } from 'rxjs';

export class PromiseBuilder
{
    build<TResult>(observable: Observable<TResult>): Promise<TResult>
    {
        return new Promise((resolve, reject) =>
        {
            observable.subscribe({
                next: resolve,
                error: reject
            });
        });
    }
}
