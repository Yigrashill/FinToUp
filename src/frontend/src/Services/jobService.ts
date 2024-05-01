
import axios from 'axios';
import { Job } from '../Types/Job';

class JobService {
    private baseUrl: string = 'http://localhost:8000/jobs';

    public async getJobs(): Promise<Job[]> {
        try {
            const response = await axios.get<Job[]>(this.baseUrl);
            return response.data;
        } catch (error) {
            throw new Error('error fetching jobs');
        }
    }
}

export const jobService = new JobService();
