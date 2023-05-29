
export interface StringParser<T>
{
    parse(value: string): T | null;
}
