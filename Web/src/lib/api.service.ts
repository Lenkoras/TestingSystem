import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpOptions } from './http-options';
import { PromiseBuilder } from './promise-builder';

@Injectable()
export class ApiService
{
    private promiseBuilder: PromiseBuilder;

    constructor(private httpClient: HttpClient)
    {
        this.promiseBuilder = new PromiseBuilder();
    }

    get<TResult>(url: string, options?: HttpOptions): Promise<TResult>
    {
        return this.promiseBuilder.build<TResult>(this.httpClient.get<TResult>(url, this.createOptions(options)));
    }

    post<TResult>(url: string, body: any, options?: HttpOptions): Promise<TResult>
    {
        return this.promiseBuilder.build<TResult>(this.httpClient.post<TResult>(url, body, this.createOptions(options)));
    }

    private createOptions(options: HttpOptions): HttpOptions
    {
        return Object.assign({}, options, { withCredentials: true });
    }
}
