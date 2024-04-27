import {useState, useEffect} from 'react'
import JobItem from './JobItem';
import jobs from '../../data/jobs.json'
import {Job} from '../../Types/Job'

// const JobList = ({isHome : boolean = false}) => {
//     const [jobs, setJobs] = useState({});
//     const [loading, setLoading] = useState(true);

//     useEffect(() => {
//         const fetchJobs = async () => {
//             const apiUrl = isHome ? '/api/jobs?_limit=3' : '/api/jobs';
//             try {
//                 const res = await fetch(apiUrl);
//                 const data = await res.json();
//                 setJobs(data);
//             }
//             catch (error){
//                 console.log('Error fetching data', error);
//             }
//             finally {
//                 setLoading(false);
//             }
//         };

//         fetchJobs();
//     }, []);

const JobList = ({isHome : boolean = false}) => {

    
    let recentJobs = jobs.slice(0,3);

  return (
    <section className="bg-blue-800 px-4 py-10">
        <div className="container-xl lg:container m-auto">
            <h2 className="text-3xl font-bold text-white mb-6 text-center">
                Browse Jobs
            </h2>
                <div className='grid grid-col-1 md:grid-cols-3 gap-6'>
                    {
                        recentJobs.map((job: Job) => (
                            <JobItem key={job.id} job={job} />
                        ))
                    }
                </div>
        </div>
      </section>
  );
};

export default JobList
