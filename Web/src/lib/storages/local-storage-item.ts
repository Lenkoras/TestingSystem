
export interface LocalStorageItem<T>
{
    get(): T | null;
    set(item: T): void;
    remove(): void;
}
