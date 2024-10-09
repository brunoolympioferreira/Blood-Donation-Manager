import { NgModule } from "@angular/core";
import { LoginComponentsModule } from "./components/login-components.module";
import { LoginComponent } from "./login.component";

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [
        LoginComponentsModule
    ],
    exports: [
        LoginComponent
    ]
})
export class LoginModule { }