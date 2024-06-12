import { FinanceType } from "../Types/Enum/FinanceType";

export function getFinanceTypeName(type: FinanceType): string {
    switch(type) {
        case FinanceType.Default:
            return "Default";
        case FinanceType.Assets:
            return "Assets";
        case FinanceType.Liabilities:
            return "Liabilities";
        default:
            return "Unknown";
    }
}

export function formatDate(dateString: string | any): string {
    const date = new Date(dateString);
    return date.toLocaleDateString('pl-PL', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric'
    });
}