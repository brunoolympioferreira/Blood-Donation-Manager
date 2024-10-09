import { NgModule } from "@angular/core";
import { LoginFormComponent } from './login-form/login-form.component';
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
    declarations: [
        LoginFormComponent
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        LoginFormComponent
    ]
})
export class LoginComponentsModule { }