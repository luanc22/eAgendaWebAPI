import { EntidadeBase } from "../../shared/entidade.model";

export class Contato extends EntidadeBase{
  public nomeContato: string;
  public email: string;
  public telefone: string;
  public empresa: string;
  public cargo: string;
 

  constructor(nomeContato: string, email: string, telefone: string, empresa: string, cargo: string, id?: string){
    super();
    
    if (id) {
      this.id = id;
    }
    
    this.nomeContato = nomeContato;
    this.email = email;
    this.telefone = telefone;
    this.empresa = empresa;
    this.cargo = cargo
  }
}