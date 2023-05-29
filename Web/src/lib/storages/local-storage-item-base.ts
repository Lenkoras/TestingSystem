import { Base64Encoder } from "../base64-encoder";
import { LocalStorageItem } from "./local-storage-item";
import { StringParser } from "src/lib/parsers/string-parser";


export abstract class LocalStorageItemBase<T> implements LocalStorageItem<T>
{
    private encoder: Base64Encoder;
    private parser: StringParser<T>;

    constructor(private key: string, parser: StringParser<T>)
    {
        this.encoder = new Base64Encoder();
        this.parser = parser;
    }

    get(): T | null
    {
        const encodedItem: string = localStorage.getItem(this.key);

        if (encodedItem == null)
        {
            return null;
        }
        try
        {
            const item: T = this.parser.parse(this.encoder.decode(encodedItem));

            return item;
        }
        catch {
            this.remove();
            return null;
        }
    }

    set(item: T): void
    {
        if (item == null)
        {
            return;
        }

        const itemText: string = JSON.stringify(item);

        if (this.parser.parse(itemText) == null)
        {
            return;
        }
        try
        {
            localStorage.setItem(this.key, this.encoder.encode(itemText));
        }
        catch (error)
        {
            console.log('encode error', error);
        }
    }

    remove(): void
    {
        localStorage.removeItem(this.key);
    }
}
