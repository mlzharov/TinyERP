export class Hashtable<T> {
    public data: any = {};
    public getKeys(): Array<string> {
        let keys: Array<string> = [];
        for (let key in this.data) {
            keys.push(key);
        }
        return keys;
    }
    public set(key: string, data: T) {
        this.data[key] = data;
    }
    public exist(key: string): boolean {
        return !!this.data[key];
    }
    public get(key: string): T {
        if (!this.exist(key)) {
            throw key + " value was not exist in Hashtable";
        }
        return this.data[key];
    }
    public remove(key: string) {
        delete this.data[key];
    }
}