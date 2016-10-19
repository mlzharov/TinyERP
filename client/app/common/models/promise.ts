export class PromiseFactory {
    public static create(): Promise {
        return new Promise();
    }
};
enum PromiseStatus {
    None,
    Success,
    Fail
}

export class Promise {
    private data: any;
    private errorData: any;
    private self: Promise = null;
    private successHandler: any = null;
    private failHandler: any = null;
    private status: PromiseStatus = PromiseStatus.None;
    constructor() {
        this.self = this;
        return this.self;
    }
    public resolve(data: any): Promise {
        this.self.data = data;
        this.self.status = PromiseStatus.Success;
        return this.execute();
    }
    public then(successHandler: any): Promise {
        this.self.successHandler = successHandler;
        return this.execute();
    }
    public error(failHandler: any): Promise {
        this.self.failHandler = failHandler;
        return this.execute();
    }
    public reject(error: any): Promise {
        this.self.errorData = error;
        this.self.status = PromiseStatus.Fail;
        return this.self.execute();
    }
    private execute(): Promise {
        if (this.self.status === PromiseStatus.Success && this.self.successHandler != null) {
            this.self.successHandler(this.self.data);
        }
        if (this.self.status === PromiseStatus.Fail && this.self.failHandler != null) {
            this.self.failHandler(this.self.errorData);
        }
        return this.self;
    }
}