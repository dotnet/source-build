@leecow commented on [Wed Jun 20 2018](https://github.com/dotnet/designs-private/issues/28)

# .NET Core in Linux Distro Repositories

This document discusses the benefits of making .NET Core available by default in Linux Distro Repositories and proposes a roadmap for getting there. Because .NET 2.1 will become LTS, this is proposed to be the first version submitted for inclusion in Linux Repositories. A critical linchpin at the intersection of several .NET Core areas is the success of the source-build project. Robust and reliable product builds, inclusion in Linux distro archives (with Microsoft as upstream maintainer or otherwise) and participation in emerging distribution tech such as Snaps all hinge, or will reap significant benefit from, the ability to easily build a complete .NET Core product from publicly available source assets.

Maturing the .NET Core source-build project to produce assets necessary to participate in Linux distro repositories is expected to net a number of benefits.

- .NET Core adoption barriers for enterprise deployments on Linux will be lowered by providing a streamlined, platform-appropriate acquisition and servicing experience.
- Linux developers can confidently adopt .NET Core for application and service solutions, knowing that the .NET Core Runtime can be automatically acquired on supported Linux distros via default repositories and that servicing updates for the Runtime through the same mechanism.
- .NET Core default, in-box acquisition experience on par with other language choices such as Go, Python, Java and Ruby.

Not implementing support for the type of deliverable described in this document may result in a number of negative outcomes.

- Continued close partnerships such as Red Hat will likely cease to be compeling.
- The .NET Core position within the Linux ecosystem will not reach equal, much less superior, footing with other languages and development frameworks.
- Avenues to first class .NET Core-based 3rd party offerings on Linux will be significantly hindered or blocked outright.
- Linux distro-provided access to servicing delivery mechanisms and security toast notifications will be blocked.
- .NET Core release product builds will have increased cost due to specialized work needed to reconcile closed build assumptions and implementations with open build requirements during each release cycle.

## Opportunity

Anecdotal evidence from the team indicates that requiring customers to acquire .NET Core through channels other than distribution defaults is a net negative. These sentiments are also in line with feedback received from the Customer Engagement team with respect to system configuration process.

Our recent telemetry shows .NET Core usage on Linux at approxiamately 40% of Windows but OS usage for generic web workloads suggests a different story. Data sites such as [Datanyze](https://www.datanyze.com/), [W3Techs](https://w3techs.com/technologies/overview/operating_system/all) and others report Linux representing significant site hosting number advantages over Windows. A caveat to this data is that Red Hat ([estimated to hold 67% of the Linux server market](https://www.gartner.com/doc/reprints?ct=150106&id=1-26VHVSW&st=sb)) data will be significantly underrepresented as RHEL telemetry is disabled by default.

Enabling customer acquisition of .NET Core through OS default mechanisms will lower the barrier of entry as well as ongoing maintenance costs.

## Build from source and Linux

Obviously, all software is built from source. The distiction in the case of software included in Linux distro repositories is the build process and requirements. All packages included in the distro are built **by** the distro and the source requirements are inclusive of build tools and build dependencies. The default position for inclusion in a distro is no pre-built binaries though there are proper exceptional cases to bootstrap builds.

All mainline Linux distros provide managed package repositories for system component and application acquisition and maintenance. The packages included in these repos undergo formal review and onboarding processes designed to ensure a level of quality control and acquisition behavior for participating packages. To participate in the repos, packages must build the final package from source checked into the distros package build infrastructure. This check in is in the form of a package containing source, package specification and other resources. Building projects from source, with binary dependencies kept to a bare minimum (eg, build bootstrapping), is a requirement across Linux distro archives.

### Red Hat and source-build

The current state of the source-build repo produces a source archive (tar.gz) from which Red Hat builds .NET Core for insertion into the Red Hat Software Collection Library system. This source archive is heavily modified from the official Microsoft product build in order to resolve commonplace Linux distribution product build requirements. Along with the source modifications, Red Hat grants extraordinary exceptions for the inclusion of pre-build binaries which would not likely be granted by other distros. Additionally, the source modifications result in a .NET Core product offering in Red Hat which is functionally different from what is offered by Microsoft. Red Hat rightfully objects to these functional differences which cast the Red Hat .NET Core offering in an inferior light.

## Proposal

There are a number of technical challenges with building the entirety of the .NET Core, ASP .NET Core, EF Core and SDK from source in the way described here. Chief among those challenges are 3rd party dependencies and even 1st party dependencies which are not open source. These can be resolved in time though the opportunity cost for not taking incremental steps could be high. 

The proposal is to start with a Runtime (NETCore.App) offering analagous to the JRE. We believe the Runtime is already quite close to what is needed to satisfy distro repository requirements making it likely that a solution could be delivered in a relatively short timeframe.

Once the first is complete, it should be a fairly simple matter to replicate the submission and approval process to a core set of 'Golden' distro for which Microsoft would serve as the upstream maintainer. Work can be scheduled across releases as necessary to bring AspNetCore.App and the SDK into the process.

### Roadmap

Fall/Winter 2018, supporting 2.1+

- Reduce the problem space and get in the door. Deliver the runtime first.
- Reduce pre-built binaries to only those required to bootstrap the build
- Select a pilot distro from among a primary distro set for which we will serve as the maintainers, at least initially, while engaging with the community to work toward self-sufficiency.
    - Fedora
    - Ubuntu
    - Debian
- Update source-build to create rpm|deb assets for submission into distro archive acceptance process
- Work through the first distro submission process
- Add distro archive maintenance to the .NET Core servicing and release processes

Spring/Summer 2019

- Rinse and repeat until identified distro list is done
- Detailed analysis requirements to bring aspnetcore.app and some form of the SDK cleanly into source-build

## Packaging Guidelines

Each distro has specific packaging guidelines along well-defined review processes.

- RPM
    - [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines)
    - [openSUSE](https://en.opensuse.org/openSUSE:Packaging_guidelines)
- DEB
    - [Debian](https://www.debian.org/doc/manuals/distribute-deb/distribute-deb.html)
    - [Ubuntu](http://packaging.ubuntu.com/html/packaging-new-software.html)


## source-build and ProdCon

In essence, source-build and ProdCon are both product construction tools. source-build is currently reactive to (ie downstream from) changes in ProdCon. This reactive nature increases operational costs and opens the door to upstream asset changes, constituent repo alterations and other events which are incompatible with producing a clean source-build release. Thought and discussion should go into how to rationalize the relationship between the two and ensure they are complimentary, rather than unintentionally antagonistic.

---

@myungjoo commented on [Wed Jun 20 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-398975349)

For Fedora/openSUSE, you may refer to https://git.tizen.org/cgit/platform/upstream/coreclr/ , which is the official .NET packaging suppport for Tizen, which is mostly packaging-compatible with openSUSE/Fedora. ( https://git.tizen.org/cgit/platform/upstream/coreclr/tree/packaging/coreclr.spec?h=tizen is the main build/packaging script)

For build results, https://build.tizen.org/package/show/Tizen:Base/coreclr can be referred, which is equivalent to build.opensuse.org . (ther is corefx as well.)

---

@tmds commented on [Thu Jun 21 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399008595)

@leecow this is awesome!!

I have some comments/questions:

> The proposal is to start with a Runtime (NETCore.App) offering analagous to the JRE.

To build the runtime, you need a cli. So the runtime+sdk seem to come together as source-buildable assets?

> the submission and approval process to a core set of 'Golden' distro for which Microsoft would serve as the upstream maintainer.

The 'golden' distro is mentioned a couple of times. I'm not sure what is a golden distro.
We should as much as possible engage the community to build and maintain packages for .NET Core.
If Microsoft services as the upstream maintainer, there should be some agreement about this with the community.

> Fedora, CentOS

The Fedora .NET SIG (https://fedoraproject.org/wiki/SIGs/DotNet) maintains .NET Core packages for Fedora.
These packages are not in official repos because they don't meet the guidelines.
In the SIG there are some Red Hatters, but all the work they do is voluntary.
(... without the strong Red Hat-Microsoft cooperation on source-build, it would be impossible to build it today)
I like Fedora to be a 'platinum' distro: built and maintained by community :)

CentOS is downstream from RHEL. So packages we build for RHEL are re-built for CentOS.
So, today, it is possible to install source-build packages on CentOS.

We can update the instructions at https://www.microsoft.com/net/learn/get-started/linux/centos to point to source-build packages.
_However_ .NET Core 2.1 has not yet been built by the CentOS community. (It should be in the near future).
A 'golden' CentOS package would be here sooner... but the 'platinum' version comes out-of-the-box... a trade-off.

> distro release timing

For RHEL, Fedora, CentOS, we are publishing new packages for new .NET Core versions at our discretion. So we publish new versions close to their release dates.
I don't know of that goes for other distros. Perhaps for some distros, new packages are aligned with distro releases? And maybe there are some special rules about adding new packages to LTS releases? Some things to investigate further...

---

@leecow commented on [Thu Jun 21 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399257130)

Thanks @tmds!

> To build the runtime, you need a cli. So the runtime+sdk seem to come together as source-buildable assets?

Yes, the open question is, is there a min SDK to be crafted which would be legal as a binary build bootstrap?

> The 'golden' distro is mentioned a couple of times. I'm not sure what is a golden distro.
We should as much as possible engage the community 

I agree in general and believe there should be a set of key distros where Microsoft plays a direct upstream maintenance role. You may end up convincing me otherwise ;-) 

---

@RheaAyase commented on [Fri Jun 22 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399350278)

> Yes, the open question is, is there a min SDK to be crafted which would be legal as a binary build bootstrap?

We can use prebuilt dotnet to build dotnet which we will use then to build dotnet for the repository... if that makes any sense. That is not the issue as much as all the other things.

> I agree in general and believe there should be a set of key distros where Microsoft plays a direct upstream maintenance role. You may end up convincing me otherwise ;-)

I mean... _we_ package for Fedora and CentOS is kinda irrelevant (it eats RHEL packages.) I don't know if there are any active people around Debian or Ubuntu, we've seen some effort towards Arch, and I've confirmed yesterday that there isn't really anything around openSUSE.

Essentially, community should have the right of way. If there isn't anyone, then Microsoft can take the role of packagers.

---

@aslicerh commented on [Fri Jun 22 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399441854)

> Essentially, community should have the right of way. If there isn't anyone, then Microsoft can take the role of packagers.

Eh, I don't have a problem if MS wants to co-release with the community. I'm not sure it makes sense (for MS) to do that, given the community is stable, because then they don't need to expend the talent and effort for that specialty niche (though maybe a little more on coordination). Basically, they can herd cats instead of herding linux devs (which is like herding cats, but with way more beer and puppies comparisons).

---

@leecow commented on [Fri Jun 22 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399502881)

@aslicerh sounds like everyday around here ;-)

This is definitely an area where we have some muscles to build. If inclusion in and maintenance of the set of primary distros turn out to be community driven, that will be great. I already had that expectation around Fedora given the awesomeness of Tom, Radka and Omair. For others, such as Ubuntu, I want us to have a close hand in getting things rolling and then see where it goes. 

---

@aslicerh commented on [Fri Jun 22 2018](https://github.com/dotnet/designs-private/issues/28#issuecomment-399512745)

@leecow Yeah, it's an interesting line to walk. On the one hand, letting the community do it helps ease your resource requirements. On the other hand, if you let go completely, and the community falls through for some reason, you may now have issues with customer perception, which (outside of the general suckitude) sucks from an enterprise standpoint.

So yeah, I could definitely understand the desire to self-provide certain distros until they are strong enough to handle themselves. Besides, those communities have to grow from somewhere, right? Being able to back off later is part of the profit for throwing the resources at it now.