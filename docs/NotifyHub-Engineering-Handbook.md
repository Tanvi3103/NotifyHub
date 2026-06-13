# NotifyHub Engineering Handbook

## Building a Distributed Notification Platform with ASP.NET Core

---

# Purpose

This handbook serves several purposes:

* Documentation for the NotifyHub project.
* A .NET backend engineering guide.
* Interview preparation material.
* A record of architectural decisions.
* A personal knowledge base.

Rather than simply documenting *what* was built, the goal is to understand *why* things are built that way.

---

# Table of Contents

## Part I — Project Overview

1. Introduction
2. Problem Statement
3. Functional Requirements
4. Non-Functional Requirements
5. High-Level Architecture
6. Why Clean Architecture?

## Part II — Solution Structure

7. Solution Structure
8. Layer Responsibilities

## Part III — C# Concepts

9. Classes

10. Properties

11. Inheritance

12. Abstraction

13. Interfaces

14. Enums

15. Collections

16. Nullable Types

17. GUID

---

# PART I — PROJECT OVERVIEW

---

# Chapter 1 — Introduction

## What is NotifyHub?

NotifyHub is a distributed notification platform built using ASP.NET Core and Clean Architecture.

Its purpose is to provide a reusable notification system capable of delivering notifications through multiple channels.

Current channel:

* In-App Notifications

Future channels:

* Email
* SMS
* Push Notifications

Future integrations:

* SignalR
* RabbitMQ
* Redis
* Docker
* GitHub Actions

---

## Real-World Examples

Modern applications constantly notify users.

Examples include:

### E-commerce

Amazon sends:

* Order confirmation emails
* Shipping updates
* Delivery notifications

### Banking Applications

Banks send:

* OTP messages
* Low balance alerts
* Transaction notifications

### Social Media

Instagram sends:

* Like notifications
* Follow requests
* Message notifications

NotifyHub aims to provide this capability in a reusable manner.

---

# Chapter 2 — Problem Statement

Many applications require notification capabilities.

Without a centralized notification platform:

* Logic becomes duplicated.
* Systems become tightly coupled.
* Scaling becomes difficult.

NotifyHub solves this by separating notification responsibilities into dedicated components.

---

# Chapter 3 — Functional Requirements

Functional requirements define what the system should do.

Current requirements:

### Create Notification

Users should be able to create notifications.

### Retrieve Notifications

Users should be able to fetch their notifications.

### Mark Notifications as Read

Notifications should support read status.

Future requirements:

* Email notifications
* SignalR notifications
* Queue-based processing
* Retry mechanism
* Dead letter queue
* Caching

---

# Chapter 4 — Non-Functional Requirements

Non-functional requirements define how the system should behave.

NotifyHub should be:

### Scalable

Support growing traffic.

### Maintainable

Easy to modify.

### Testable

Components should be independently testable.

### Reliable

Failures should be recoverable.

### Extensible

New channels should be easy to add.

---

# Chapter 5 — High-Level Architecture

Current architecture:

```text
Client
↓
API Layer
↓
Application Layer
↓
Infrastructure Layer
↓
SQL Server
```

## Request Flow

Suppose a client creates a notification.

The flow is:

```text
Client
↓
Controller
↓
Application Layer
↓
Infrastructure Layer
↓
Entity Framework Core
↓
SQL Server
```

## Why Layered Architecture?

Layered architecture provides:

* Separation of concerns
* Better maintainability
* Easier testing
* Flexibility

---

# Chapter 6 — Why Clean Architecture?

## What is Clean Architecture?

Clean Architecture is an architectural style proposed by Robert C. Martin (Uncle Bob).

It organizes software into independent layers.

## Core Principle

Inner layers should not depend on outer layers.

Dependencies always point inward.

### Domain

Contains business rules.

### Application

Contains use cases.

### Infrastructure

Contains external implementations.

### API

Exposes endpoints.

## Benefits

### Maintainability

Changes remain isolated.

### Testability

Business logic can be tested independently.

### Scalability

Large systems remain manageable.

### Loose Coupling

Components remain independent.

---

# PART II — SOLUTION STRUCTURE

---

# Chapter 7 — Solution Structure

Current structure:

```text
NotifyHub

src
│
├── NotifyHub.API
├── NotifyHub.Application
├── NotifyHub.Domain
└── NotifyHub.Infrastructure

tests
│
└── NotifyHub.UnitTests

docs
│
└── NotifyHub-Engineering-Handbook.md
```

## Why Multiple Projects?

Following the Single Responsibility Principle, each project should have one purpose.

### NotifyHub.API

Responsible for:

* Controllers
* Middleware
* Dependency Injection
* Swagger
* Application startup

### NotifyHub.Application

Responsible for:

* DTOs
* Interfaces
* Use Cases

### NotifyHub.Domain

Responsible for:

* Business entities
* Enums
* Business rules

### NotifyHub.Infrastructure

Responsible for:

* Database access
* Entity Framework Core
* External services

---

# Chapter 8 — Layer Responsibilities

## Domain Layer

Contains business entities and rules.

Examples:

* User
* Notification
* NotificationLog

This layer should have no dependency on other layers.

## Application Layer

Defines what the system should do.

Examples:

* DTOs
* Interfaces

## Infrastructure Layer

Provides implementations.

Examples:

* Database access
* Entity Framework Core

## API Layer

Acts as the entry point.

It receives HTTP requests and returns HTTP responses.

---

# PART III — C# CONCEPTS

---

# Chapter 9 — Classes

## What is a Class?

A class is a blueprint used to create objects.

Examples from NotifyHub:

* User
* Notification
* NotificationLog

## Why Do We Need Classes?

Classes allow us to model real-world entities.

Example:

A notification has:

* Title
* Message
* Status

Therefore, we create a Notification class.

## Advantages

* Reusability
* Encapsulation
* Maintainability

## Interview Questions

### What is a class?

### Difference between class and object?

Status:

✅ Covered

---

# Chapter 10 — Properties

## What are Properties?

Properties represent the state of an object.

Examples:

* Title
* Message
* Status
* CreatedAt

## Why Do We Need Properties?

They allow objects to store information.

Example:

```csharp
public string Title { get; set; } = string.Empty;
```

Status:

✅ Covered

---

# Chapter 11 — Inheritance

## What is Inheritance?

Inheritance allows one class to reuse properties and behavior from another class.

## Why Use Inheritance?

Without inheritance, User, Notification and NotificationLog would all contain:

* Id
* CreatedAt

leading to duplication.

## Solution

Create:

```csharp
BaseEntity
```

Then inherit from it.

Current hierarchy:

```text
BaseEntity
     ↑
User

Notification

NotificationLog
```

## Benefits

* Reusability
* Maintainability
* Reduced duplication

## Interview Questions

### What is inheritance?

### Difference between inheritance and composition?

### Can C# support multiple inheritance?

No.

Status:

✅ Covered

---

# Chapter 12 — Abstraction

## What is Abstraction?

Abstraction focuses on behavior rather than implementation.

Current example:

```csharp
INotificationService
```

The interface describes:

```csharp
CreateNotificationAsync()

GetNotificationsByUserIdAsync()

MarkAsReadAsync()
```

without explaining how these methods work.

## Benefits

* Loose coupling
* Testability
* Flexibility

Status:

✅ Covered

---

# Chapter 13 — Interfaces

## What is an Interface?

An interface defines a contract.

Classes implementing the interface must provide the implementation.

Current interface:

```csharp
INotificationService
```

## Advantages

* Decoupling
* Easier testing
* Dependency Injection support

Status:

✅ Covered

---

# Chapter 14 — Enums

Current enums:

```csharp
NotificationStatus

Pending
Sent
Failed
Read
```

```csharp
NotificationChannel

Email
InApp
```

## Benefits

* Readability
* Type safety
* Avoid magic numbers

Status:

✅ Covered

---

# Chapter 15 — Collections

Examples:

```csharp
ICollection<Notification>

ICollection<NotificationLog>
```

These represent one-to-many relationships.

Status:

✅ Covered

---

# Chapter 16 — Nullable Types

Example:

```csharp
DateTime? ReadAt
```

Meaning:

A notification may or may not have been read.

Status:

✅ Covered

---

# Chapter 17 — GUID

NotifyHub uses GUIDs as primary keys.

Examples:

```csharp
Id

UserId

NotificationId
```

## Advantages

* Globally unique
* Useful for distributed systems
* Difficult to predict

Status:

✅ Covered

---

# Current Progress

Completed through:

✅ Step 3 — Interfaces

---

# Upcoming Topics

⚠️ Services

⚠️ Dependency Injection

⚠️ Controllers

⚠️ REST APIs

⚠️ Swagger

⚠️ SignalR

⚠️ RabbitMQ

⚠️ Redis

⚠️ Unit Testing

⚠️ SOLID Principles

⚠️ Design Patterns

⚠️ System Design
