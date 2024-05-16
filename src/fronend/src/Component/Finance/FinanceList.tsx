import React, { useEffect, useState } from 'react'
import { Finance } from '../../Types/Interface/Finance'
import { financeService } from '../../Services/FinanceService';

const FinanceList = () => {

    const [finances, setFinances] = useState<Finance[]>([]);

    useEffect(() => {
        const fetchFinances = async () => {
            try {
                const data  = await financeService.getJobs();
                setFinances(data);
            }
            catch (error) {
                console.log(error);
            }
        }   
        fetchFinances();
    }, []);

  return (
    <>
        <div className="container-xl bg-indigo-700">
            <h2 className="text-3xl font-bold text-white mb-6 ml-36">
                My Jobs:
            </h2>
            <div className="grid grid-col-1 text-white text-center gap-6">
            {
                finances.map((finances : Finance) => (
                <div>
                    <p>{finances.id}</p>  
                    <p>{finances.title}</p>  
                    <p>{finances.amount}</p>  
                    <p>{finances.financeType}</p>  
                    <p>{finances.createrd}</p>  
                    <p>{finances.updated}</p>  
                </div>
                ))
            }
            </div>


        </div>
    </>
  )
}

export default FinanceList

// const JobList: React.FC<JobListProps> = ({isHome}) => {

//     const [jobs, setJobs] = useState<Job[]>([]);
//     const [loading, setLoading] = useState(false);