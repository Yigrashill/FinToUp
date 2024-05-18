import { FinanceType } from "../../Enum/FinanceType";
import { BaseEntity } from "../BaseEntity";

export interface Finance extends BaseEntity {
    title: string;
    financeType: FinanceType; 
    amount?: number;
}