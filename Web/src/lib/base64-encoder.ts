export class Base64Encoder
{
    encode(text: string): string
    {
        return btoa(encodeURIComponent(text));
    }

    decode(base64Str: string): string
    {
        return decodeURIComponent(atob(base64Str));
    }
}
