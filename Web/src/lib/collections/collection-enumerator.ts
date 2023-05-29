export interface CollectionEnumerator<T>
{
    get currentIndex(): number;
    get count(): number;
    get current(): T;
    moveNext(): boolean;
    movePrevious(): boolean;
    moveTo(index: number): boolean;
    reset(): void;
}
