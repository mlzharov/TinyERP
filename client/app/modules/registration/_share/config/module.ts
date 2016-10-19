import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {UserLogin} from "../../users/userLogin";
import {AuthenticationMode} from "../../../../common/enum";
// console.log("registraiton module");
let umModule: IModule = createModule();
export default umModule;
function createModule() {
    let module = new Module("app/modules/registration", "registration");
    module.addRoutes([
        { path: "/login", name: "Login", component: UserLogin, data: { authentication: AuthenticationMode.None } }
    ]);
    return module;
}