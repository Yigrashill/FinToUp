
import axios from 'axios';
import { Job } from '../Types/Job';

class JobService {
    private baseUrl: string = 'http://localhost:8000/jobs';

    public async getJobs(num : number) : Promise<Job[]> {
        try {
            const response = await axios.get<Job[]>(this.baseUrl + `?_limit=${num}`);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching jobs');
        }
    }

    public async getJob(num : number) : Promise<Job>{
        try {
            const response = await axios.get<Job>(this.baseUrl + `/${num}`);
            return response.data;
        }
        catch (error) {
            throw new Error('Error fetching job');
        }
    }
}

export const jobService = new JobService();
