import axios from "axios";
import { Finance } from "../Types/Interface/Finance";

class FinanceService{
    private baseUrl: string = 'http://localhost:5000/api/finances';

    public async getJobs() : Promise<Finance[]> {
        try {
            const response = await axios.get<Finance[]>(this.baseUrl);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching jobs');
        }
    };

}

export const financeService = new FinanceService();