import { Galery } from "./Galery";

export class User{
    constructor(public Id : number,
            public Username : string,
            public Email : string,
            public Password : string,
            public Galeries : Galery[]){}
}