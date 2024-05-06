import React, { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom';
import { Job } from '../../Types/Job';
import { jobService } from '../../Services/jobService';
import { FaExclamationTriangle, FaMapMarked } from 'react-icons/fa';

const JobComp = () => {

  const navigate = useNavigate();
  const { id } = useParams<{ id: number | any }>();
  const [job, setJob] = useState<Job>();

  useEffect(() => {
      const fetchJob = async () => {
          try {
              const data = await jobService.getJob(id);
              setJob(data);
          }
          catch(error) {
              console.log('Error: ', error);
          }
      }

      fetchJob();
  }, []);

  const onDeleteClick = (jobId : number) =>{
      const confirm = window.confirm(
          'Are you sure, you want to delete this job ?'
      );


      if (!confirm ) return;

      console.log(jobId);

      // delete(jobId);
      // toast.success('Job deleted successfull');

      navigate('/jobs');
  }

  return (
    <>

    {job 
        ? ( 
           
            <section className='bg-indigo-700 min-h-[960px]'>
            <div className='container m-auto py-10 px-6'>
                <div className='grid grid-cols-1 md:grid-cols-70/30 w-full gap-6'>
                    <main>
                        <div className='bg-white p-6 rounded-lg shadow-md text-center md:text-left'>
                            <div className='text-gret-500 mb-4'>
                                {job.type}
                            </div>
                            <h1 className='text-3xl font-bold mb-4'>
                                {job.title}
                            </h1>
                            <div className="text-grat-500 mb-4 flex align-middle">
                                <FaMapMarked className='text-orange-700 mr-1' />
                                <p className='text-orange-700'> {job.location} </p>
                            </div>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow-md mt-6">
                            <h3 className="text-indigo-800 text-lg font-bold mb-6">
                                Job Description
                            </h3>
                            <p className="mb-4">
                                {job.description}
                                </p>
                            <h3 className="text-indigo-800 text-lg font-bold mb-2">
                                Salary
                            </h3>
                            <p className="mb-4">
                                {job.salary}
                                </p>
                        </div>
                    </main>


                <aside>
                    <div className="bg-white p-6 rounded-lg shadow md">
                        <h3 className="text-xl font-bold mb-6">
                            Company Info
                        </h3>
                        <h2 className="text-2xl">
                            {job.company.name}
                        </h2>
                        <p className="my-2">
                            {job.company.description}
                        </p>
                        <hr className="my-4" />

                        <h3 className="text-xl">
                            Contact Email:
                        </h3>
                        <p className="my-2 bg-indigo-100 p-2 font-bold">
                            {job.company.contactEmail}
                        </p>
                        <h3 className="text-xl">
                            Contact Phone:
                        </h3>
                        <p className="my-2 bg-indigo-100 p2 font-bold">
                            {'  '}
                            {job.company.contactPhone}
                        </p>
                    </div>


                    <div className="bg-white p-6 rounded-lg shadow-md mt-6">
                        <h3 className="text-xl font-bold mb-6">
                            Manage Job
                        </h3>
                        <div className='text-white text-center'>
                        <Link
                            to= {`/edit-job/${job.id}`}
                            className="bg-indigo-500 hover:bg-indigo-600 font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block">
                            Edit Job
                        </Link>
                        <button
                            onClick={() => onDeleteClick(job.id)} 
                            className='bg-red-500 hover:bg-red-600  font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block'>
                            Delete Job
                        </button>
                        <Link
                            to='/jobs'
                            className='bg-orange-500 hover:bg-orange-600 font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block'>
                            Go Back
                        </Link>
                        </div>
                    
                    </div>

                </aside>

                </div>
            </div>
    </section>

    ) 
    : ( 

        <section className='text-center font-bold flex flex-col justify-center items-center h-96'>
        <div className="text-6xl ">
          <FaExclamationTriangle className='inline text-yellow-500 mr-4'  />
              404 Not Found
        </div>
     
  
          <p className='text-xl mb-5'>This job does not exist</p>
              <Link
                  to='/'
                  className='text-white bg-orange-500 hover:bg-orange-600 rounded-md px-3 py-2 mt-4'>
                  Go Back
              </Link>
      </section>
     )}
   
   </>
  )
}

export default JobComp