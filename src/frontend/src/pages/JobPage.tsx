import React, { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom';
import { Job } from '../Types/Job';
import { FaExclamationTriangle, FaMapMarked } from 'react-icons/fa';



const JobPage = () => {
    const { id } = useParams();
    const [job, setJob] = useState<Job>();

    useEffect(() => {
        const fetchJob = async () => {
            try {
                const rest = await fetch(`http://localhost:8000/jobs/${id}`);
                const data = await rest.json();

                setJob(data);
            }
            catch(error) {
                console.log('Error: ', error);
            }
        }

        fetchJob();
    }, []);

  return (


    <>
    {job 
    ? ( 
        <section className='bg-indigo-100'>
            <div className='container m-auto py-10 px-6'>
                <div className='grid grid-cols-1 md:grid-cols-70/20 w-full gap-6'>
                    <main>
                        <div className='bg-white p-6 rounded-lg shadow-md text-center md:text-left'>
                            <div className='text-gret-500 mb-4'>
                                {job.type}
                            </div>
                            <h1 className='text-3xl font-bold mb-4'>
                                {job.title}
                            </h1>
                            <div className="text-grat-500 mb-4 flex align-middle justify-center">
                                <FaMapMarked className='text-orange-700 mr-1' />
                                <p className='text-orange-700'> {job.location} </p>
                            </div>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow-md mt-6">
                            <h3 className="text-indigo-800 text-lg font-bold mb-6">
                                Job Description
                            </h3>
                        </div>
                    </main>
                </div>
            </div>
        </section>

    ) 
    : ( 
        <div className='text-blue-800 font-bold text-6xl mt-20' >        
            <FaExclamationTriangle className='inline text-yellow-500 mb-1 mr-2'  />
            This job dont exist
        </div>
     )}
     <section className='text-center justify-center mt-20 h-96'>
        <div className='mt-20 text-2xl'>
            <Link
                to='/jobs'
                className='text-white bg-orange-500 hover:bg-blue-900 rounded-md pl-6 pr-6 p-4'>
                Go Back
            </Link>
        </div>
    </section>
     </>
  )
}


export default JobPage