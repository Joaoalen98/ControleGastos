export interface NovaMovimentacaoModel {
    valor: number;
    descricao: string;
    dataEntrada: string;
    categoriaReceita?: string;
    categoriaDespesa?: string;
    usuarioId: string;
}