import guidHelper from "../../../../common/helpers/guidHelper";
export class Model {
    public items: Array<any> = [];
    public import(steps: Array<any>) {
        if (!steps) { return; }
        let currIndex = 0;
        let self: Model = this;
        steps.forEach((step: any) => {
            self.items.push({ id: step.id, title: step.title, description: step.description, index: ++currIndex });
        });
    }
}