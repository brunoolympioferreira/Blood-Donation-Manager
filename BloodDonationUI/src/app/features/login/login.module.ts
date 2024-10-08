import { NgModule } from "@angular/core";
import { LoginComponentsModule } from "./components/login-components.module";
import { LoginComponent } from "./login.component";
import { SharedModule } from "../../shared/shared.module";

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [
        SharedModule,
        LoginComponentsModule
    ],
    exports: [
        LoginComponent
    ]
})
export class LoginModule { }