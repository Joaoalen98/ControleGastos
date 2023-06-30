import { Usuario } from "src/app/interfaces/usuario.model";

export interface LoginCorretoModel {
    usuario: Usuario,
    token: string;
}