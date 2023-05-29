import { CollectionEnumerator } from "./collection-enumerator";


export class ArrayEnumerator<T> implements CollectionEnumerator<T>
{
    private currentIndexValue: number;

    constructor(private collection: T[])
    {
        this.currentIndexValue = -1;
    }

    get currentIndex(): number {
        return this.currentIndexValue;
    }

    get count(): number
    {
        return this.collection.length;
    }

    get current(): T
    {
        return this.collection[this.currentIndexValue];
    }

    moveNext(): boolean
    {
        return this.moveTo(this.currentIndexValue + 1);
    }

    movePrevious(): boolean
    {
        return this.moveTo(this.currentIndexValue - 1);
    }

    moveTo(index: number): boolean
    {
        if (index > -1 && index < this.collection.length)
        {
            this.currentIndexValue = index;
            return true;
        }
        return false;
    }

    reset(): void
    {
        this.currentIndexValue = -1;
    }
}
