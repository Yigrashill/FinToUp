import axios from "axios";
import { Finance } from "../Types/Interfaces/Finance/Finance";

class FinanceService{
    private baseUrl: string = 'http://localhost:5000/api/finances';

    public async getFinances() : Promise<Finance[]> {
        try {
            const response = await axios.get<Finance[]>(this.baseUrl);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching jobs');
        }
    };

}

export const financeService = new FinanceService();