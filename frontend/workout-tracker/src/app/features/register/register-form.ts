import { FormControl, FormGroup } from "@angular/forms";

export type RegisterForm = FormGroup<{
    email: FormControl<string>;
    password: FormControl<string>;
    firstName: FormControl<string | null>;
    lastName: FormControl<string | null>;
}>;