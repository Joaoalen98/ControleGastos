export interface Movimentacao {
    id: string;
    usuarioId: string;
    valor: number;
    descricao: number;
    dataEntrada: string;
    categoriaReceita: number;
    categoriaReceitaString: string;
    categoriaDespesa: number;
    categoriaDespesaString: string;
}