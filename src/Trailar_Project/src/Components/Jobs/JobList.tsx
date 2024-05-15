import React, {useState, useEffect} from 'react'
import JobItem from './JobItem';
import {Job} from '../../Types/Job'
import {JobListProps} from '../../Types/Props/JobListProps';
import Spinner from '../../Components/Spinner';
import { jobService } from '../../Services/jobService';

const JobList: React.FC<JobListProps> = ({isHome}) => {

    const [jobs, setJobs] = useState<Job[]>([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const fetchJobs = async () => {
            setLoading(true);

            try {
                let num : number = isHome ? 3 : 1_000_000;
                const data = await jobService.getJobs(num);
                setJobs(data);  
            }
            catch(error) {
                console.log('Error fetching jobs', error);
            }
            finally {
                setLoading(false);
            }
        }

        fetchJobs();
    }, []);

        
   return (
        <>
            <div className="container-xl lg:container m-auto">
            {loading 
                ? 
                ( <>
                     <h2 className="text-3xl font-bold text-yellow mb-6 text-center">
                        loadding..
                    </h2>
                        <Spinner loading = { loading } />
                </>)
                : 
                ( <>
                    <h2 className="text-3xl font-bold text-white mb-6 text-center">
                        Browse Jobs 
                    </h2>
                    <div className='grid grid-col-1 md:grid-cols-3 gap-6'>
                    {
                        jobs.map((job: Job) => (
                            <JobItem key={job.id} job={job} />
                        ))
                    } 
                   </div>
                </>)
            }
            </div>
        </>
  );
};

export default JobList
